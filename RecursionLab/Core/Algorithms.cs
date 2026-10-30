using System.Runtime.CompilerServices;

namespace RecursionLab.Core;

public sealed class Probe
{
    public long Calls;
    public int MaxDepth;
    public void Enter(int depth) { Calls++; if (depth > MaxDepth) MaxDepth = depth; }
}

public sealed record Metric(long N, double Ms, long Calls, int MaxDepth, long Result);

public sealed class AlgorithmInfo
{
    public string Name { get; init; }
    public string Description { get; init; }
    public string ResultLabel { get; init; }
    public long Min { get; init; }
    public long Max { get; init; }
    public long DefFrom { get; init; }
    public long DefTo { get; init; }
    public long DefStep { get; init; }
    public Func<long, Probe, long> Run { get; init; }
    public override string ToString() => Name;
}

public static class Algorithms
{
    // ---- Algoritmos recursivos instrumentados (cuentan llamadas y profundidad) ----

    static long Hanoi(Probe p, int n, int depth)
    {
        p.Enter(depth);
        if (n == 1) return 1;
        return Hanoi(p, n - 1, depth + 1) + 1 + Hanoi(p, n - 1, depth + 1);
    }

    static long Fib(Probe p, int n, int depth)
    {
        p.Enter(depth);
        if (n < 2) return n;
        return unchecked(Fib(p, n - 1, depth + 1) + Fib(p, n - 2, depth + 1));
    }

    static long FibMemo(Probe p, int n, long[] memo, int depth)
    {
        p.Enter(depth);
        RuntimeHelpers.EnsureSufficientExecutionStack();
        if (n < 2) return n;
        if (memo[n] != 0) return memo[n];
        return memo[n] = unchecked(FibMemo(p, n - 1, memo, depth + 1) + FibMemo(p, n - 2, memo, depth + 1));
    }

    static long Sum(Probe p, long n, int depth)
    {
        p.Enter(depth);
        RuntimeHelpers.EnsureSufficientExecutionStack();
        if (n == 0) return 0;
        return n + Sum(p, n - 1, depth + 1);
    }

    static long Queens(Probe p, int n, int row, int cols, int d1, int d2, int depth)
    {
        p.Enter(depth);
        if (row == n) return 1;
        long total = 0;
        int free = ~(cols | d1 | d2) & ((1 << n) - 1);
        while (free != 0)
        {
            int bit = free & -free;
            free ^= bit;
            total += Queens(p, n, row + 1, cols | bit, (d1 | bit) << 1, (d2 | bit) >> 1, depth + 1);
        }
        return total;
    }

    public static readonly AlgorithmInfo[] All =
    {
        new()
        {
            Name = "Torres de Hanoi", ResultLabel = "Movimientos",
            Description = "Torres de Hanoi: T(n) = 2·T(n-1) + 1.\r\nLlamadas y movimientos = 2^n - 1 (crecimiento exponencial), pero la profundidad de pila es solo n (lineal).",
            Min = 1, Max = 27, DefFrom = 1, DefTo = 24, DefStep = 1,
            Run = (n, p) => Hanoi(p, (int)n, 1)
        },
        new()
        {
            Name = "Fibonacci ingenuo", ResultLabel = "fib(n)",
            Description = "Fibonacci sin memoización: T(n) = T(n-1) + T(n-2) + 1.\r\nEl árbol de llamadas crece ~1.618^n (exponencial) con subproblemas repetidos; la profundidad es n.",
            Min = 1, Max = 42, DefFrom = 10, DefTo = 36, DefStep = 2,
            Run = (n, p) => Fib(p, (int)n, 1)
        },
        new()
        {
            Name = "Fibonacci con memoización", ResultLabel = "fib(n) (mod 2^64)",
            Description = "Fibonacci con caché: cada subproblema se calcula una vez -> O(n) llamadas.\r\nLa profundidad de pila sigue siendo n: la memoización arregla el tiempo, no la pila.",
            Min = 10, Max = 2_000_000, DefFrom = 1000, DefTo = 20000, DefStep = 1000,
            Run = (n, p) => FibMemo(p, (int)n, new long[n + 1], 1)
        },
        new()
        {
            Name = "Suma recursiva (profundidad pura)", ResultLabel = "Suma 1..n",
            Description = "sum(n) = n + sum(n-1): O(n) llamadas y profundidad n.\r\nSirve para observar cuánta recursión soporta la pila (hilo de 256 MB). Si se agota, se detecta y se informa.",
            Min = 1000, Max = 5_000_000, DefFrom = 50_000, DefTo = 500_000, DefStep = 50_000,
            Run = (n, p) => Sum(p, n, 1)
        },
        new()
        {
            Name = "N-Reinas (backtracking)", ResultLabel = "Soluciones",
            Description = "Cuenta todas las soluciones de N-Reinas con backtracking y máscaras de bits.\r\nProfundidad = n (una por fila), pero el número de nodos explorados crece de forma superexponencial.",
            Min = 4, Max = 13, DefFrom = 4, DefTo = 12, DefStep = 1,
            Run = (n, p) => Queens(p, (int)n, 0, 0, 0, 0, 1)
        }
    };
}

public static class Benchmark
{
    /// <summary>Recorre tamaños de n y mide tiempo (mediana de 'repeats'), llamadas y profundidad máxima.</summary>
    public static List<Metric> Sweep(AlgorithmInfo a, long start, long end, long step, int repeats, out string warning)
    {
        warning = null;
        var list = new List<Metric>();
        step = Math.Max(1, step);

        try { a.Run(start, new Probe()); } catch (InsufficientExecutionStackException) { }   // calentamiento JIT

        for (long n = start; n <= end; n += step)
        {
            var times = new List<double>();
            Probe last = null; long result = 0;
            try
            {
                for (int r = 0; r < repeats; r++)
                {
                    var p = new Probe();
                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    result = a.Run(n, p);
                    sw.Stop();
                    times.Add(sw.Elapsed.TotalMilliseconds);
                    last = p;
                }
            }
            catch (InsufficientExecutionStackException)
            {
                warning = $"¡Pila agotada en n = {n:N0}! La recursión superó el espacio de pila disponible (se detuvo el barrido).";
                break;
            }
            times.Sort();
            list.Add(new Metric(n, times[times.Count / 2], last.Calls, last.MaxDepth, result));
        }
        return list;
    }

    /// <summary>Profundidad máxima alcanzable con distintos tamaños de pila.</summary>
    public static List<(int Mb, int Depth)> StackLimits(int[] sizesMb)
    {
        var res = new List<(int, int)>();
        foreach (int mb in sizesMb)
        {
            int depth = 0;
            var t = new Thread(() =>
            {
                try { Dive(ref depth, 1); }
                catch (InsufficientExecutionStackException) { }
            }, mb * 1024 * 1024);
            t.Start(); t.Join();
            res.Add((mb, depth));
        }
        return res;
    }

    static long Dive(ref int maxDepth, int d)
    {
        maxDepth = d;
        RuntimeHelpers.EnsureSufficientExecutionStack();
        return 1 + Dive(ref maxDepth, d + 1);
    }
}
