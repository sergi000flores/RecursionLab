using System.Data;
using System.Diagnostics;
using RecursionLab.Core;

namespace RecursionLab;

public partial class MainForm : Form
{
    // ---- Hanoi ----
    private readonly System.Windows.Forms.Timer _hanoiTimer = new();
    private List<(int Disc, int From, int To)> _hanoiMoves = new();
    private int _hanoiIdx;
    private string _hanoiStatsBase = "";

    // ---- Laberinto ----
    private readonly System.Windows.Forms.Timer _mazeTimer = new() { Interval = 20 };
    private int[,] _maze;
    private MazeGenResult _gen;
    private MazeSolveResult _solve;
    private int _mazePhase, _mazeIdx;

    // ---- Análisis ----
    private List<Metric> _metrics;
    private AlgorithmInfo _metricsAlg;

    public MainForm()
    {
        InitializeComponent();

        _hanoiTimer.Tick += HanoiTimer_Tick;
        _mazeTimer.Tick += MazeTimer_Tick;

        cboAlgoritmo.Items.AddRange(Algorithms.All);
        cboMetrica.SelectedIndex = 0;
        cboAlgoritmo.SelectedIndex = 0;
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        hanoiCanvas.Reset((int)nudDiscos.Value);
        await GenerateMazeAsync();
    }

    // =====================================================================
    //  1. TORRES DE HANOI
    // =====================================================================
    private void nudDiscos_ValueChanged(object sender, EventArgs e)
    {
        _hanoiTimer.Stop();
        hanoiCanvas.Reset((int)nudDiscos.Value);
    }

    private void btnHanoiReiniciar_Click(object sender, EventArgs e)
    {
        _hanoiTimer.Stop();
        hanoiCanvas.Reset((int)nudDiscos.Value);
        lstMovimientos.Items.Clear();
        lblHanoiStats.Text = "Pulsa \"Resolver y animar\".";
    }

    private void btnHanoiResolver_Click(object sender, EventArgs e)
    {
        _hanoiTimer.Stop();
        int n = (int)nudDiscos.Value;
        hanoiCanvas.Reset(n);

        var solver = new HanoiSolver { Log = new() };
        var sw = Stopwatch.StartNew();
        solver.Solve(n, 0, 1, 2);
        sw.Stop();

        _hanoiMoves = solver.Log;
        const string names = "ABC";
        lstMovimientos.BeginUpdate();
        lstMovimientos.Items.Clear();
        for (int i = 0; i < _hanoiMoves.Count; i++)
        {
            var m = _hanoiMoves[i];
            lstMovimientos.Items.Add($"{i + 1,5}. Disco {m.Disc,2}: {names[m.From]} → {names[m.To]}");
        }
        lstMovimientos.EndUpdate();

        _hanoiStatsBase =
            $"Discos: {n}\r\n" +
            $"Movimientos: {solver.Moves:N0}  (2^n − 1 = {(1L << n) - 1:N0})\r\n" +
            $"Llamadas recursivas: {solver.Calls:N0}\r\n" +
            $"Profundidad máx. de recursión: {solver.MaxDepth}\r\n" +
            $"Tiempo de cómputo: {sw.Elapsed.TotalMilliseconds:N3} ms";
        lblHanoiStats.Text = _hanoiStatsBase;

        _hanoiIdx = 0;
        _hanoiTimer.Interval = Math.Max(5, (int)(800 / Math.Pow(tbVelH.Value, 1.5)));
        _hanoiTimer.Start();
    }

    private void HanoiTimer_Tick(object sender, EventArgs e)
    {
        if (_hanoiIdx >= _hanoiMoves.Count)
        {
            _hanoiTimer.Stop();
            lblHanoiStats.Text = _hanoiStatsBase + "\r\n¡Resuelto!";
            return;
        }
        var m = _hanoiMoves[_hanoiIdx];
        hanoiCanvas.MoveDisc(m.From, m.To);
        lstMovimientos.SelectedIndex = _hanoiIdx;
        _hanoiIdx++;
    }

    // =====================================================================
    //  2. LABERINTO
    // =====================================================================
    private async void btnMazeGenerar_Click(object sender, EventArgs e) => await GenerateMazeAsync();

    private async Task GenerateMazeAsync()
    {
        _mazeTimer.Stop();
        SetMazeButtons(false);

        int size = (int)nudTam.Value;
        if (size % 2 == 0) size++;
        if (size > nudTam.Maximum) size -= 2;
        nudTam.Value = size;
        int seed = (int)nudSemilla.Value;

        _gen = await StackRunner.RunAsync(() => MazeGenerator.Generate(size, size, seed));
        _maze = _gen.Grid;
        _solve = null;
        mazeCanvas.SetMaze(_maze);

        lblMazeStats.Text =
            $"Laberinto {size}×{size} generado con DFS recursivo (backtracker).\r\n" +
            $"Llamadas: {_gen.Calls:N0}   Profundidad máx.: {_gen.MaxDepth:N0}   Tiempo: {_gen.Ms:N3} ms";
        SetMazeButtons(true);
    }

    private async void btnMazeResolver_Click(object sender, EventArgs e)
    {
        if (_maze == null) return;
        _mazeTimer.Stop();
        SetMazeButtons(false);
        mazeCanvas.ClearSolution();

        var grid = _maze;
        _solve = await StackRunner.RunAsync(() => MazeSolver.Solve(grid));

        lblMazeStats.Text =
            $"Resolviendo… llamadas: {_solve.Calls:N0}   Profundidad máx.: {_solve.MaxDepth:N0}   Tiempo de cómputo: {_solve.Ms:N3} ms\r\n" +
            $"Celdas exploradas: {_solve.Visits.Count:N0}   Longitud del camino: {_solve.Path.Count:N0}";

        _mazePhase = 0; _mazeIdx = 0;
        _mazeTimer.Start();
    }

    private void MazeTimer_Tick(object sender, EventArgs e)
    {
        if (_solve == null) { _mazeTimer.Stop(); return; }
        int perTick = (int)Math.Pow(2, tbVelM.Value - 1);

        if (_mazePhase == 0)
        {
            for (int k = 0; k < perTick && _mazeIdx < _solve.Visits.Count; k++, _mazeIdx++)
                mazeCanvas.MarkVisited(_solve.Visits[_mazeIdx].R, _solve.Visits[_mazeIdx].C);
            if (_mazeIdx >= _solve.Visits.Count) { _mazePhase = 1; _mazeIdx = 0; }
        }
        else
        {
            for (int k = 0; k < perTick && _mazeIdx < _solve.Path.Count; k++, _mazeIdx++)
                mazeCanvas.MarkPath(_solve.Path[_mazeIdx].R, _solve.Path[_mazeIdx].C);
            if (_mazeIdx >= _solve.Path.Count)
            {
                _mazeTimer.Stop();
                lblMazeStats.Text =
                    $"Resuelto con backtracking recursivo.   Llamadas: {_solve.Calls:N0}   Profundidad máx.: {_solve.MaxDepth:N0}   Tiempo: {_solve.Ms:N3} ms\r\n" +
                    $"Celdas exploradas: {_solve.Visits.Count:N0}   Camino final: {_solve.Path.Count:N0} celdas   " +
                    $"(descartadas por retroceso: {_solve.Visits.Count - _solve.Path.Count:N0})";
                SetMazeButtons(true);
            }
        }
        mazeCanvas.Invalidate();
    }

    private void SetMazeButtons(bool enabled)
    {
        btnMazeGenerar.Enabled = enabled;
        btnMazeResolver.Enabled = enabled;
    }

    // =====================================================================
    //  3. ANÁLISIS DE PROFUNDIDAD
    // =====================================================================
    private void cboAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboAlgoritmo.SelectedItem is not AlgorithmInfo a) return;

        nudDesde.Minimum = a.Min; nudDesde.Maximum = a.Max;
        nudHasta.Minimum = a.Min; nudHasta.Maximum = a.Max;
        nudDesde.Value = a.DefFrom;
        nudHasta.Value = a.DefTo;
        nudPaso.Value = Math.Min(a.DefStep, nudPaso.Maximum);
        txtAnalisis.Text = a.Description;
    }

    private async void btnEjecutar_Click(object sender, EventArgs e)
    {
        var alg = (AlgorithmInfo)cboAlgoritmo.SelectedItem;
        long start = (long)nudDesde.Value, end = (long)nudHasta.Value, step = (long)nudPaso.Value;
        int reps = (int)nudRep.Value;
        if (end < start) { MessageBox.Show("«Hasta» debe ser mayor o igual que «Desde»."); return; }

        SetAnalysisButtons(false);
        txtAnalisis.Text = "Ejecutando mediciones… (puede tardar unos segundos)";
        try
        {
            string warning = null;
            var metrics = await StackRunner.RunAsync(() => Benchmark.Sweep(alg, start, end, step, reps, out warning));

            _metrics = metrics; _metricsAlg = alg;

            var table = new DataTable();
            foreach (var col in new[] { "n", "Tiempo (ms)", "Llamadas", "Profundidad", alg.ResultLabel })
                table.Columns.Add(col, typeof(string));
            foreach (var m in metrics)
                table.Rows.Add(m.N.ToString("N0"), m.Ms.ToString("N3"), m.Calls.ToString("N0"),
                               m.MaxDepth.ToString("N0"), m.Result.ToString("N0"));
            dgvResultados.DataSource = table;

            txtAnalisis.Text = Analyzer.Describe(alg, metrics, warning);
            UpdateChart();
        }
        catch (Exception ex)
        {
            txtAnalisis.Text = "Error: " + ex.Message;
        }
        finally { SetAnalysisButtons(true); }
    }

    private async void btnLimitePila_Click(object sender, EventArgs e)
    {
        SetAnalysisButtons(false);
        txtAnalisis.Text = "Midiendo profundidad máxima por tamaño de pila…";
        var res = await Task.Run(() => Benchmark.StackLimits(new[] { 1, 4, 16, 64, 256 }));
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Profundidad máxima de recursión según el tamaño de pila del hilo:");
        sb.AppendLine("(función mínima con detección mediante EnsureSufficientExecutionStack)");
        sb.AppendLine(new string('-', 70));
        foreach (var (mb, depth) in res)
            sb.AppendLine($"  Pila {mb,4} MB  →  ≈ {depth,12:N0} llamadas   (≈ {(mb * 1024.0 * 1024.0) / Math.Max(1, depth):N0} bytes por llamada)");
        sb.AppendLine();
        sb.AppendLine("Conclusión: la profundidad máxima es proporcional al tamaño de pila. Pasarse provoca");
        sb.AppendLine("StackOverflow (proceso terminado). Por eso el laberinto y los barridos usan hilos de 256 MB.");
        txtAnalisis.Text = sb.ToString();
        SetAnalysisButtons(true);
    }

    private void cboMetrica_SelectedIndexChanged(object sender, EventArgs e) => UpdateChart();
    private void chkLog_CheckedChanged(object sender, EventArgs e) => UpdateChart();

    private void UpdateChart()
    {
        if (_metrics == null || _metricsAlg == null) return;
        Func<Metric, double> sel = cboMetrica.SelectedIndex switch
        {
            0 => m => m.Ms,
            1 => m => m.Calls,
            _ => m => m.MaxDepth
        };
        string metric = cboMetrica.SelectedItem?.ToString() ?? "";
        chart.SetData($"{_metricsAlg.Name}: {metric} vs n", "n (profundidad / tamaño del problema)", metric,
            _metrics.Select(m => ((double)m.N, sel(m))).ToList(), chkLog.Checked);
    }

    private void SetAnalysisButtons(bool enabled)
    {
        btnEjecutar.Enabled = enabled;
        btnLimitePila.Enabled = enabled;
        cboAlgoritmo.Enabled = enabled;
    }
}
