namespace RecursionLab
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabMain = new TabControl();
            tabHanoi = new TabPage();
            hanoiCanvas = new RecursionLab.Controls.HanoiCanvas();
            pnlHanoiRight = new Panel();
            lstMovimientos = new ListBox();
            lblHanoiStats = new Label();
            pnlHanoiTop = new Panel();
            lblDiscos = new Label();
            nudDiscos = new NumericUpDown();
            btnHanoiResolver = new Button();
            btnHanoiReiniciar = new Button();
            lblVelH = new Label();
            tbVelH = new TrackBar();
            tabMaze = new TabPage();
            mazeCanvas = new RecursionLab.Controls.MazeCanvas();
            lblMazeStats = new Label();
            pnlMazeTop = new Panel();
            lblTam = new Label();
            nudTam = new NumericUpDown();
            lblSemilla = new Label();
            nudSemilla = new NumericUpDown();
            btnMazeGenerar = new Button();
            btnMazeResolver = new Button();
            lblVelM = new Label();
            tbVelM = new TrackBar();
            tabAnalisis = new TabPage();
            chart = new RecursionLab.Controls.ChartControl();
            dgvResultados = new DataGridView();
            txtAnalisis = new TextBox();
            flowAnalisis = new FlowLayoutPanel();
            lblAlg = new Label();
            cboAlgoritmo = new ComboBox();
            lblDesde = new Label();
            nudDesde = new NumericUpDown();
            lblHasta = new Label();
            nudHasta = new NumericUpDown();
            lblPaso = new Label();
            nudPaso = new NumericUpDown();
            lblRep = new Label();
            nudRep = new NumericUpDown();
            lblMetrica = new Label();
            cboMetrica = new ComboBox();
            chkLog = new CheckBox();
            btnEjecutar = new Button();
            btnLimitePila = new Button();
            tabMain.SuspendLayout();
            tabHanoi.SuspendLayout();
            pnlHanoiRight.SuspendLayout();
            pnlHanoiTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiscos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVelH).BeginInit();
            tabMaze.SuspendLayout();
            pnlMazeTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSemilla).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVelM).BeginInit();
            tabAnalisis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            flowAnalisis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDesde).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudHasta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPaso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRep).BeginInit();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabHanoi);
            tabMain.Controls.Add(tabMaze);
            tabMain.Controls.Add(tabAnalisis);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Location = new Point(0, 0);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1100, 700);
            tabMain.TabIndex = 0;
            // 
            // tabHanoi
            // 
            tabHanoi.Controls.Add(hanoiCanvas);
            tabHanoi.Controls.Add(pnlHanoiRight);
            tabHanoi.Controls.Add(pnlHanoiTop);
            tabHanoi.Location = new Point(4, 29);
            tabHanoi.Name = "tabHanoi";
            tabHanoi.Size = new Size(1092, 667);
            tabHanoi.TabIndex = 0;
            tabHanoi.Text = "1. Torres de Hanoi";
            tabHanoi.UseVisualStyleBackColor = true;
            // 
            // hanoiCanvas
            // 
            hanoiCanvas.BackColor = Color.White;
            hanoiCanvas.Dock = DockStyle.Fill;
            hanoiCanvas.Location = new Point(0, 56);
            hanoiCanvas.Name = "hanoiCanvas";
            hanoiCanvas.Size = new Size(772, 611);
            hanoiCanvas.TabIndex = 2;
            // 
            // pnlHanoiRight
            // 
            pnlHanoiRight.Controls.Add(lstMovimientos);
            pnlHanoiRight.Controls.Add(lblHanoiStats);
            pnlHanoiRight.Dock = DockStyle.Right;
            pnlHanoiRight.Location = new Point(772, 56);
            pnlHanoiRight.Name = "pnlHanoiRight";
            pnlHanoiRight.Size = new Size(320, 611);
            pnlHanoiRight.TabIndex = 1;
            // 
            // lstMovimientos
            // 
            lstMovimientos.Dock = DockStyle.Fill;
            lstMovimientos.Font = new Font("Consolas", 9.75F);
            lstMovimientos.FormattingEnabled = true;
            lstMovimientos.Location = new Point(0, 150);
            lstMovimientos.Name = "lstMovimientos";
            lstMovimientos.Size = new Size(320, 461);
            lstMovimientos.TabIndex = 1;
            // 
            // lblHanoiStats
            // 
            lblHanoiStats.BorderStyle = BorderStyle.FixedSingle;
            lblHanoiStats.Dock = DockStyle.Top;
            lblHanoiStats.Location = new Point(0, 0);
            lblHanoiStats.Name = "lblHanoiStats";
            lblHanoiStats.Padding = new Padding(8);
            lblHanoiStats.Size = new Size(320, 150);
            lblHanoiStats.TabIndex = 0;
            lblHanoiStats.Text = "Pulsa \"Resolver y animar\".";
            // 
            // pnlHanoiTop
            // 
            pnlHanoiTop.Controls.Add(lblDiscos);
            pnlHanoiTop.Controls.Add(nudDiscos);
            pnlHanoiTop.Controls.Add(btnHanoiResolver);
            pnlHanoiTop.Controls.Add(btnHanoiReiniciar);
            pnlHanoiTop.Controls.Add(lblVelH);
            pnlHanoiTop.Controls.Add(tbVelH);
            pnlHanoiTop.Dock = DockStyle.Top;
            pnlHanoiTop.Location = new Point(0, 0);
            pnlHanoiTop.Name = "pnlHanoiTop";
            pnlHanoiTop.Size = new Size(1092, 56);
            pnlHanoiTop.TabIndex = 0;
            // 
            // lblDiscos
            // 
            lblDiscos.AutoSize = true;
            lblDiscos.Location = new Point(12, 19);
            lblDiscos.Name = "lblDiscos";
            lblDiscos.Size = new Size(54, 20);
            lblDiscos.TabIndex = 0;
            lblDiscos.Text = "Discos:";
            // 
            // nudDiscos
            // 
            nudDiscos.Location = new Point(72, 15);
            nudDiscos.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudDiscos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDiscos.Name = "nudDiscos";
            nudDiscos.Size = new Size(60, 27);
            nudDiscos.TabIndex = 1;
            nudDiscos.Value = new decimal(new int[] { 4, 0, 0, 0 });
            nudDiscos.ValueChanged += nudDiscos_ValueChanged;
            // 
            // btnHanoiResolver
            // 
            btnHanoiResolver.Location = new Point(150, 12);
            btnHanoiResolver.Name = "btnHanoiResolver";
            btnHanoiResolver.Size = new Size(150, 32);
            btnHanoiResolver.TabIndex = 2;
            btnHanoiResolver.Text = "Resolver y animar";
            btnHanoiResolver.UseVisualStyleBackColor = true;
            btnHanoiResolver.Click += btnHanoiResolver_Click;
            // 
            // btnHanoiReiniciar
            // 
            btnHanoiReiniciar.Location = new Point(310, 12);
            btnHanoiReiniciar.Name = "btnHanoiReiniciar";
            btnHanoiReiniciar.Size = new Size(100, 32);
            btnHanoiReiniciar.TabIndex = 3;
            btnHanoiReiniciar.Text = "Reiniciar";
            btnHanoiReiniciar.UseVisualStyleBackColor = true;
            btnHanoiReiniciar.Click += btnHanoiReiniciar_Click;
            // 
            // lblVelH
            // 
            lblVelH.AutoSize = true;
            lblVelH.Location = new Point(430, 19);
            lblVelH.Name = "lblVelH";
            lblVelH.Size = new Size(78, 20);
            lblVelH.TabIndex = 4;
            lblVelH.Text = "Velocidad:";
            // 
            // tbVelH
            // 
            tbVelH.Location = new Point(514, 8);
            tbVelH.Maximum = 10;
            tbVelH.Minimum = 1;
            tbVelH.Name = "tbVelH";
            tbVelH.Size = new Size(170, 56);
            tbVelH.TabIndex = 5;
            tbVelH.Value = 5;
            // 
            // tabMaze
            // 
            tabMaze.Controls.Add(mazeCanvas);
            tabMaze.Controls.Add(lblMazeStats);
            tabMaze.Controls.Add(pnlMazeTop);
            tabMaze.Location = new Point(4, 29);
            tabMaze.Name = "tabMaze";
            tabMaze.Size = new Size(1092, 667);
            tabMaze.TabIndex = 1;
            tabMaze.Text = "2. Laberinto (backtracking)";
            tabMaze.UseVisualStyleBackColor = true;
            // 
            // mazeCanvas
            // 
            mazeCanvas.BackColor = Color.FromArgb(235, 235, 240);
            mazeCanvas.Dock = DockStyle.Fill;
            mazeCanvas.Location = new Point(0, 56);
            mazeCanvas.Name = "mazeCanvas";
            mazeCanvas.Size = new Size(1092, 521);
            mazeCanvas.TabIndex = 2;
            // 
            // lblMazeStats
            // 
            lblMazeStats.BorderStyle = BorderStyle.FixedSingle;
            lblMazeStats.Dock = DockStyle.Bottom;
            lblMazeStats.Location = new Point(0, 577);
            lblMazeStats.Name = "lblMazeStats";
            lblMazeStats.Padding = new Padding(8);
            lblMazeStats.Size = new Size(1092, 90);
            lblMazeStats.TabIndex = 1;
            // 
            // pnlMazeTop
            // 
            pnlMazeTop.Controls.Add(lblTam);
            pnlMazeTop.Controls.Add(nudTam);
            pnlMazeTop.Controls.Add(lblSemilla);
            pnlMazeTop.Controls.Add(nudSemilla);
            pnlMazeTop.Controls.Add(btnMazeGenerar);
            pnlMazeTop.Controls.Add(btnMazeResolver);
            pnlMazeTop.Controls.Add(lblVelM);
            pnlMazeTop.Controls.Add(tbVelM);
            pnlMazeTop.Dock = DockStyle.Top;
            pnlMazeTop.Location = new Point(0, 0);
            pnlMazeTop.Name = "pnlMazeTop";
            pnlMazeTop.Size = new Size(1092, 56);
            pnlMazeTop.TabIndex = 0;
            // 
            // lblTam
            // 
            lblTam.AutoSize = true;
            lblTam.Location = new Point(12, 19);
            lblTam.Name = "lblTam";
            lblTam.Size = new Size(76, 20);
            lblTam.TabIndex = 0;
            lblTam.Text = "Tamaño:";
            // 
            // nudTam
            // 
            nudTam.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            nudTam.Location = new Point(90, 15);
            nudTam.Maximum = new decimal(new int[] { 301, 0, 0, 0 });
            nudTam.Minimum = new decimal(new int[] { 11, 0, 0, 0 });
            nudTam.Name = "nudTam";
            nudTam.Size = new Size(70, 27);
            nudTam.TabIndex = 1;
            nudTam.Value = new decimal(new int[] { 31, 0, 0, 0 });
            // 
            // lblSemilla
            // 
            lblSemilla.AutoSize = true;
            lblSemilla.Location = new Point(180, 19);
            lblSemilla.Name = "lblSemilla";
            lblSemilla.Size = new Size(64, 20);
            lblSemilla.TabIndex = 2;
            lblSemilla.Text = "Semilla:";
            // 
            // nudSemilla
            // 
            nudSemilla.Location = new Point(248, 15);
            nudSemilla.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudSemilla.Name = "nudSemilla";
            nudSemilla.Size = new Size(85, 27);
            nudSemilla.TabIndex = 3;
            nudSemilla.Value = new decimal(new int[] { 42, 0, 0, 0 });
            // 
            // btnMazeGenerar
            // 
            btnMazeGenerar.Location = new Point(350, 12);
            btnMazeGenerar.Name = "btnMazeGenerar";
            btnMazeGenerar.Size = new Size(120, 32);
            btnMazeGenerar.TabIndex = 4;
            btnMazeGenerar.Text = "Generar";
            btnMazeGenerar.UseVisualStyleBackColor = true;
            btnMazeGenerar.Click += btnMazeGenerar_Click;
            // 
            // btnMazeResolver
            // 
            btnMazeResolver.Location = new Point(480, 12);
            btnMazeResolver.Name = "btnMazeResolver";
            btnMazeResolver.Size = new Size(140, 32);
            btnMazeResolver.TabIndex = 5;
            btnMazeResolver.Text = "Resolver y animar";
            btnMazeResolver.UseVisualStyleBackColor = true;
            btnMazeResolver.Click += btnMazeResolver_Click;
            // 
            // lblVelM
            // 
            lblVelM.AutoSize = true;
            lblVelM.Location = new Point(640, 19);
            lblVelM.Name = "lblVelM";
            lblVelM.Size = new Size(78, 20);
            lblVelM.TabIndex = 6;
            lblVelM.Text = "Velocidad:";
            // 
            // tbVelM
            // 
            tbVelM.Location = new Point(722, 8);
            tbVelM.Maximum = 10;
            tbVelM.Minimum = 1;
            tbVelM.Name = "tbVelM";
            tbVelM.Size = new Size(170, 56);
            tbVelM.TabIndex = 7;
            tbVelM.Value = 6;
            // 
            // tabAnalisis
            // 
            tabAnalisis.Controls.Add(chart);
            tabAnalisis.Controls.Add(dgvResultados);
            tabAnalisis.Controls.Add(txtAnalisis);
            tabAnalisis.Controls.Add(flowAnalisis);
            tabAnalisis.Location = new Point(4, 29);
            tabAnalisis.Name = "tabAnalisis";
            tabAnalisis.Size = new Size(1092, 667);
            tabAnalisis.TabIndex = 2;
            tabAnalisis.Text = "3. Análisis de profundidad";
            tabAnalisis.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            chart.BackColor = Color.White;
            chart.Dock = DockStyle.Fill;
            chart.Location = new Point(520, 80);
            chart.Name = "chart";
            chart.Size = new Size(572, 427);
            chart.TabIndex = 3;
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.BackgroundColor = SystemColors.Window;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Dock = DockStyle.Left;
            dgvResultados.Location = new Point(0, 80);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersVisible = false;
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.Size = new Size(520, 427);
            dgvResultados.TabIndex = 2;
            // 
            // txtAnalisis
            // 
            txtAnalisis.BackColor = Color.FromArgb(250, 250, 245);
            txtAnalisis.Dock = DockStyle.Bottom;
            txtAnalisis.Font = new Font("Consolas", 9.75F);
            txtAnalisis.Location = new Point(0, 507);
            txtAnalisis.Multiline = true;
            txtAnalisis.Name = "txtAnalisis";
            txtAnalisis.ReadOnly = true;
            txtAnalisis.ScrollBars = ScrollBars.Vertical;
            txtAnalisis.Size = new Size(1092, 160);
            txtAnalisis.TabIndex = 1;
            // 
            // flowAnalisis
            // 
            flowAnalisis.AutoSize = true;
            flowAnalisis.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowAnalisis.Controls.Add(lblAlg);
            flowAnalisis.Controls.Add(cboAlgoritmo);
            flowAnalisis.Controls.Add(lblDesde);
            flowAnalisis.Controls.Add(nudDesde);
            flowAnalisis.Controls.Add(lblHasta);
            flowAnalisis.Controls.Add(nudHasta);
            flowAnalisis.Controls.Add(lblPaso);
            flowAnalisis.Controls.Add(nudPaso);
            flowAnalisis.Controls.Add(lblRep);
            flowAnalisis.Controls.Add(nudRep);
            flowAnalisis.Controls.Add(btnEjecutar);
            flowAnalisis.Controls.Add(btnLimitePila);
            flowAnalisis.Controls.Add(lblMetrica);
            flowAnalisis.Controls.Add(cboMetrica);
            flowAnalisis.Controls.Add(chkLog);
            flowAnalisis.Dock = DockStyle.Top;
            flowAnalisis.Location = new Point(0, 0);
            flowAnalisis.Name = "flowAnalisis";
            flowAnalisis.Padding = new Padding(4);
            flowAnalisis.Size = new Size(1092, 80);
            flowAnalisis.TabIndex = 0;
            // 
            // lblAlg
            // 
            lblAlg.AutoSize = true;
            lblAlg.Margin = new Padding(3, 8, 3, 0);
            lblAlg.Name = "lblAlg";
            lblAlg.TabIndex = 0;
            lblAlg.Text = "Algoritmo:";
            // 
            // cboAlgoritmo
            // 
            cboAlgoritmo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAlgoritmo.FormattingEnabled = true;
            cboAlgoritmo.Name = "cboAlgoritmo";
            cboAlgoritmo.Size = new Size(270, 28);
            cboAlgoritmo.TabIndex = 1;
            cboAlgoritmo.SelectedIndexChanged += cboAlgoritmo_SelectedIndexChanged;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Margin = new Padding(12, 8, 3, 0);
            lblDesde.Name = "lblDesde";
            lblDesde.TabIndex = 2;
            lblDesde.Text = "Desde n:";
            // 
            // nudDesde
            // 
            nudDesde.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudDesde.Name = "nudDesde";
            nudDesde.Size = new Size(100, 27);
            nudDesde.TabIndex = 3;
            nudDesde.ThousandsSeparator = true;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Margin = new Padding(12, 8, 3, 0);
            lblHasta.Name = "lblHasta";
            lblHasta.TabIndex = 4;
            lblHasta.Text = "Hasta n:";
            // 
            // nudHasta
            // 
            nudHasta.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudHasta.Name = "nudHasta";
            nudHasta.Size = new Size(100, 27);
            nudHasta.TabIndex = 5;
            nudHasta.ThousandsSeparator = true;
            // 
            // lblPaso
            // 
            lblPaso.AutoSize = true;
            lblPaso.Margin = new Padding(12, 8, 3, 0);
            lblPaso.Name = "lblPaso";
            lblPaso.TabIndex = 6;
            lblPaso.Text = "Paso:";
            // 
            // nudPaso
            // 
            nudPaso.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPaso.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPaso.Name = "nudPaso";
            nudPaso.Size = new Size(90, 27);
            nudPaso.TabIndex = 7;
            nudPaso.ThousandsSeparator = true;
            nudPaso.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblRep
            // 
            lblRep.AutoSize = true;
            lblRep.Margin = new Padding(12, 8, 3, 0);
            lblRep.Name = "lblRep";
            lblRep.TabIndex = 8;
            lblRep.Text = "Repeticiones:";
            // 
            // nudRep
            // 
            nudRep.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            nudRep.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRep.Name = "nudRep";
            nudRep.Size = new Size(50, 27);
            nudRep.TabIndex = 9;
            nudRep.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // btnEjecutar
            // 
            btnEjecutar.Margin = new Padding(12, 3, 3, 3);
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new Size(100, 30);
            btnEjecutar.TabIndex = 10;
            btnEjecutar.Text = "Ejecutar";
            btnEjecutar.UseVisualStyleBackColor = true;
            btnEjecutar.Click += btnEjecutar_Click;
            // 
            // btnLimitePila
            // 
            btnLimitePila.Name = "btnLimitePila";
            btnLimitePila.Size = new Size(190, 30);
            btnLimitePila.TabIndex = 11;
            btnLimitePila.Text = "Probar límite de pila";
            btnLimitePila.UseVisualStyleBackColor = true;
            btnLimitePila.Click += btnLimitePila_Click;
            // 
            // lblMetrica
            // 
            lblMetrica.AutoSize = true;
            lblMetrica.Margin = new Padding(12, 8, 3, 0);
            lblMetrica.Name = "lblMetrica";
            lblMetrica.TabIndex = 12;
            lblMetrica.Text = "Gráfico:";
            // 
            // cboMetrica
            // 
            cboMetrica.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMetrica.FormattingEnabled = true;
            cboMetrica.Items.AddRange(new object[] { "Tiempo (ms)", "Llamadas", "Profundidad máxima" });
            cboMetrica.Name = "cboMetrica";
            cboMetrica.Size = new Size(170, 28);
            cboMetrica.TabIndex = 13;
            cboMetrica.SelectedIndexChanged += cboMetrica_SelectedIndexChanged;
            // 
            // chkLog
            // 
            chkLog.AutoSize = true;
            chkLog.Margin = new Padding(12, 6, 3, 0);
            chkLog.Name = "chkLog";
            chkLog.TabIndex = 14;
            chkLog.Text = "Escala log (Y)";
            chkLog.UseVisualStyleBackColor = true;
            chkLog.CheckedChanged += chkLog_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(tabMain);
            MinimumSize = new Size(900, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recursividad: Hanoi, Laberinto y Análisis de profundidad";
            Load += MainForm_Load;
            tabMain.ResumeLayout(false);
            tabHanoi.ResumeLayout(false);
            pnlHanoiRight.ResumeLayout(false);
            pnlHanoiTop.ResumeLayout(false);
            pnlHanoiTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiscos).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVelH).EndInit();
            tabMaze.ResumeLayout(false);
            pnlMazeTop.ResumeLayout(false);
            pnlMazeTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTam).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSemilla).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVelM).EndInit();
            tabAnalisis.ResumeLayout(false);
            tabAnalisis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            flowAnalisis.ResumeLayout(false);
            flowAnalisis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDesde).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudHasta).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPaso).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRep).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabHanoi;
        private TabPage tabMaze;
        private TabPage tabAnalisis;
        private RecursionLab.Controls.HanoiCanvas hanoiCanvas;
        private Panel pnlHanoiRight;
        private ListBox lstMovimientos;
        private Label lblHanoiStats;
        private Panel pnlHanoiTop;
        private Label lblDiscos;
        private NumericUpDown nudDiscos;
        private Button btnHanoiResolver;
        private Button btnHanoiReiniciar;
        private Label lblVelH;
        private TrackBar tbVelH;
        private RecursionLab.Controls.MazeCanvas mazeCanvas;
        private Label lblMazeStats;
        private Panel pnlMazeTop;
        private Label lblTam;
        private NumericUpDown nudTam;
        private Label lblSemilla;
        private NumericUpDown nudSemilla;
        private Button btnMazeGenerar;
        private Button btnMazeResolver;
        private Label lblVelM;
        private TrackBar tbVelM;
        private RecursionLab.Controls.ChartControl chart;
        private DataGridView dgvResultados;
        private TextBox txtAnalisis;
        private FlowLayoutPanel flowAnalisis;
        private Label lblAlg;
        private ComboBox cboAlgoritmo;
        private Label lblDesde;
        private NumericUpDown nudDesde;
        private Label lblHasta;
        private NumericUpDown nudHasta;
        private Label lblPaso;
        private NumericUpDown nudPaso;
        private Label lblRep;
        private NumericUpDown nudRep;
        private Label lblMetrica;
        private ComboBox cboMetrica;
        private CheckBox chkLog;
        private Button btnEjecutar;
        private Button btnLimitePila;
    }
}
