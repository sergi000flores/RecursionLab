using System.Text;

namespace RecursionLab.Core;

public static class Analyzer
{
    static (double Slope, double R2) Fit(double[] x, double[] y)
    {
        int n = x.Length;
        double mx = x.Average(), my = y.Average();
        double sxx = 0, sxy = 0, syy = 0;
        for (int i = 0; i < n; i++)
        {
            sxx += (x[i] - mx) * (x[i] - mx);
            sxy += (x[i] - mx) * (y[i] - my);
            syy += (y[i] - my) * (y[i] - my);
        }
        if (sxx == 0 || syy == 0) return (0, 0);
        return (sxy / sxx, (sxy * sxy) / (sxx * syy));
    }

    public static string Describe(AlgorithmInfo a, List<Metric> m, string warning)
    {
        var sb = new StringBuilder();
        sb.AppendLine(a.Description);
        sb.AppendLine(new string('-', 70));

        if (m.Count == 0) { sb.AppendLine(warning ?? "Sin datos."); return sb.ToString(); }

        var last = m[^1];
        sb.AppendLine($"Rango medido: n = {m[0].N:N0} … {last.N:N0}  ({m.Count} puntos)");
        sb.AppendLine($"En n = {last.N:N0}: {last.Calls:N0} llamadas, profundidad máx. {last.MaxDepth:N0}, {last.Ms:N3} ms");
        if (last.Calls > 0)
            sb.AppendLine($"Coste medio por llamada: {last.Ms * 1e6 / last.Calls:N1} ns");

        if (m.Count >= 3 && m.All(p => p.Calls > 0 && p.N > 0))
        {
            var ns = m.Select(p => (double)p.N).ToArray();
            var lc = m.Select(p => Math.Log(p.Calls)).ToArray();
            var exp = Fit(ns, lc);                                  // ln(calls) vs n
            var pow = Fit(ns.Select(v => Math.Log(v)).ToArray(), lc);       // ln(calls) vs ln(n)

            if (exp.R2 > pow.R2 + 0.005 && exp.Slope > 0.05)
                sb.AppendLine($"Modelo de llamadas: EXPONENCIAL ≈ {Math.Exp(exp.Slope):N3}^n  (R² = {exp.R2:N4})");
            else
                sb.AppendLine($"Modelo de llamadas: POLINÓMICO ≈ n^{pow.Slope:N2}  (R² = {pow.R2:N4})" +
                              (Math.Abs(pow.Slope - 1) < 0.15 ? "  → lineal O(n)" : ""));
        }

        double depthRatio = (double)last.MaxDepth / last.N;
        sb.AppendLine($"Profundidad / n = {depthRatio:N2}  → la pila crece {(depthRatio >= 0.9 && depthRatio <= 1.1 ? "linealmente con n" : "de forma distinta a n")}.");
        if (last.Calls > 0 && last.MaxDepth > 0)
            sb.AppendLine($"Relación llamadas / profundidad = {(double)last.Calls / last.MaxDepth:N1}  (trabajo total frente a memoria de pila usada).");

        if (warning != null) { sb.AppendLine(); sb.AppendLine(warning); }
        return sb.ToString();
    }
}
