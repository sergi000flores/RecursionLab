using System.Drawing.Drawing2D;

namespace RecursionLab.Controls;

/// <summary>Gráfico de líneas simple dibujado con GDI+ (escala lineal o logarítmica en Y).</summary>
public class ChartControl : Control
{
    private List<(double X, double Y)> _pts = new();
    private string _title = "", _xLabel = "", _yLabel = "";
    private bool _logY;

    public ChartControl()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        BackColor = Color.White;
    }

    public void SetData(string title, string xLabel, string yLabel, List<(double X, double Y)> pts, bool logY)
    {
        _title = title; _xLabel = xLabel; _yLabel = yLabel; _pts = pts; _logY = logY;
        Invalidate();
    }

    static string Fmt(double v)
    {
        double a = Math.Abs(v);
        if (a >= 1e9) return (v / 1e9).ToString("0.##") + "G";
        if (a >= 1e6) return (v / 1e6).ToString("0.##") + "M";
        if (a >= 1e4) return (v / 1e3).ToString("0.#") + "K";
        if (a >= 100) return v.ToString("0");
        if (a >= 1) return v.ToString("0.##");
        return v.ToString("0.###");
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(BackColor);
        using var titleFont = new Font("Segoe UI", 10.5f, FontStyle.Bold);
        using var font = new Font("Segoe UI", 8.5f);
        using var center = new StringFormat { Alignment = StringAlignment.Center };
        using var right = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

        var plot = new RectangleF(75, 40, Width - 75 - 25, Height - 40 - 55);
        g.DrawString(_title, titleFont, Brushes.Black, Width / 2f, 10, center);

        if (_pts.Count == 0 || plot.Width < 60 || plot.Height < 60)
        {
            g.DrawString("Ejecuta un análisis para ver el gráfico", font, Brushes.Gray, Width / 2f, Height / 2f, center);
            return;
        }

        double xMin = _pts.Min(p => p.X), xMax = _pts.Max(p => p.X);
        if (xMax <= xMin) xMax = xMin + 1;

        Func<double, double> T = v => _logY ? Math.Log10(Math.Max(v, 1e-6)) : v;
        double yMin = _pts.Min(p => T(p.Y)), yMax = _pts.Max(p => T(p.Y));
        if (_logY) { yMin = Math.Floor(yMin); yMax = Math.Ceiling(yMax); }
        else { yMin = Math.Min(0, yMin); yMax *= 1.08; }
        if (yMax <= yMin) yMax = yMin + 1;

        using var gridPen = new Pen(Color.Gainsboro);
        using var axisPen = new Pen(Color.Black, 1.5f);

        for (int i = 0; i <= 5; i++)
        {
            float py = plot.Bottom - plot.Height * i / 5f;
            g.DrawLine(gridPen, plot.Left, py, plot.Right, py);
            double tv = yMin + (yMax - yMin) * i / 5.0;
            g.DrawString(Fmt(_logY ? Math.Pow(10, tv) : tv), font, Brushes.Black,
                new RectangleF(0, py - 10, plot.Left - 6, 20), right);

            float px = plot.Left + plot.Width * i / 5f;
            g.DrawLine(gridPen, px, plot.Top, px, plot.Bottom);
            g.DrawString(Fmt(xMin + (xMax - xMin) * i / 5.0), font, Brushes.Black, px, plot.Bottom + 6, center);
        }
        g.DrawRectangle(axisPen, plot.X, plot.Y, plot.Width, plot.Height);

        g.DrawString(_xLabel, font, Brushes.DimGray, plot.Left + plot.Width / 2, Height - 22, center);
        var st = g.Save();
        g.TranslateTransform(16, plot.Top + plot.Height / 2);
        g.RotateTransform(-90);
        g.DrawString(_yLabel + (_logY ? " (escala log)" : ""), font, Brushes.DimGray, 0, 0, center);
        g.Restore(st);

        var mapped = _pts.Select(p => new PointF(
            (float)(plot.Left + (p.X - xMin) / (xMax - xMin) * plot.Width),
            (float)(plot.Bottom - (T(p.Y) - yMin) / (yMax - yMin) * plot.Height))).ToArray();

        using var linePen = new Pen(Color.RoyalBlue, 2.2f);
        if (mapped.Length >= 2) g.DrawLines(linePen, mapped);
        foreach (var m in mapped)
        {
            g.FillEllipse(Brushes.White, m.X - 4, m.Y - 4, 8, 8);
            g.DrawEllipse(linePen, m.X - 4, m.Y - 4, 8, 8);
        }
    }
}
