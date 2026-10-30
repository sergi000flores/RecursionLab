namespace RecursionLab.Core;

/// <summary>Torres de Hanoi recursivo con registro de movimientos (para la simulación).</summary>
public sealed class HanoiSolver
{
    public long Calls { get; private set; }
    public long Moves { get; private set; }
    public int MaxDepth { get; private set; }
    public List<(int Disc, int From, int To)> Log { get; init; }

    /// <summary>Mueve los n discos superiores de 'src' a 'dst' usando 'via' como auxiliar.</summary>
    public void Solve(int n, int src, int dst, int via, int depth = 1)
    {
        Calls++;
        if (depth > MaxDepth) MaxDepth = depth;

        if (n == 1)                       // caso base
        {
            Moves++;
            Log?.Add((1, src, dst));
            return;
        }

        Solve(n - 1, src, via, dst, depth + 1);   // 1) n-1 discos a la torre auxiliar
        Moves++;
        Log?.Add((n, src, dst));                  // 2) el disco mayor al destino
        Solve(n - 1, via, dst, src, depth + 1);   // 3) n-1 discos sobre el mayor
    }
}
