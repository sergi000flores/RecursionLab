namespace RecursionLab.Core;

public sealed record MazeGenResult(int[,] Grid, long Calls, int MaxDepth, double Ms);

public sealed record MazeSolveResult(
    List<(int R, int C)> Visits, List<(int R, int C)> Path,
    long Calls, int MaxDepth, double Ms, bool Found);

/// <summary>Genera un laberinto perfecto con "recursive backtracker" (DFS recursivo). 1 = muro, 0 = camino.</summary>
public static class MazeGenerator
{
    private static readonly (int dr, int dc)[] Dirs = { (-1, 0), (0, 1), (1, 0), (0, -1) };

    public static MazeGenResult Generate(int rows, int cols, int seed)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        var grid = new int[rows, cols];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++) grid[r, c] = 1;

        var rnd = new Random(seed);
        long calls = 0; int maxDepth = 0;

        void Carve(int r, int c, int depth)
        {
            calls++;
            if (depth > maxDepth) maxDepth = depth;
            grid[r, c] = 0;

            var order = Dirs.OrderBy(_ => rnd.Next()).ToArray();
            foreach (var (dr, dc) in order)
            {
                int nr = r + 2 * dr, nc = c + 2 * dc;
                if (nr > 0 && nr < rows - 1 && nc > 0 && nc < cols - 1 && grid[nr, nc] == 1)
                {
                    grid[r + dr, c + dc] = 0;   // derriba el muro intermedio
                    Carve(nr, nc, depth + 1);   // llamada recursiva
                }
            }
        }

        Carve(1, 1, 1);
        sw.Stop();
        return new MazeGenResult(grid, calls, maxDepth, sw.Elapsed.TotalMilliseconds);
    }
}

/// <summary>Resuelve el laberinto con backtracking recursivo (DFS): avanza, y si no hay salida, retrocede.</summary>
public static class MazeSolver
{
    private static readonly (int dr, int dc)[] Dirs = { (0, 1), (1, 0), (0, -1), (-1, 0) };

    public static MazeSolveResult Solve(int[,] grid)
    {
        int rows = grid.GetLength(0), cols = grid.GetLength(1);
        int gr = rows - 2, gc = cols - 2;
        var seen = new bool[rows, cols];
        var visits = new List<(int, int)>();
        var path = new List<(int, int)>();
        long calls = 0; int maxDepth = 0;
        var sw = System.Diagnostics.Stopwatch.StartNew();

        bool Dfs(int r, int c, int depth)
        {
            calls++;
            if (depth > maxDepth) maxDepth = depth;
            seen[r, c] = true;
            visits.Add((r, c));

            if (r == gr && c == gc) { path.Add((r, c)); return true; }   // caso base: meta

            foreach (var (dr, dc) in Dirs)
            {
                int nr = r + dr, nc = c + dc;
                if (grid[nr, nc] == 0 && !seen[nr, nc] && Dfs(nr, nc, depth + 1))
                {
                    path.Add((r, c));   // al volver del éxito se reconstruye el camino
                    return true;
                }
            }
            return false;               // callejón sin salida -> backtrack
        }

        bool found = Dfs(1, 1, 1);
        sw.Stop();
        path.Reverse();
        return new MazeSolveResult(visits, path, calls, maxDepth, sw.Elapsed.TotalMilliseconds, found);
    }
}
