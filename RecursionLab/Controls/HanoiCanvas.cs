using System.Drawing.Drawing2D;

namespace RecursionLab.Controls;

public class HanoiCanvas : Control
{
    private List<int>[] _pegs = { new(), new(), new() };
    private int _discs;

    public HanoiCanvas()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        BackColor = Color.White;
    }

    public void Reset(int discs)
    {
        _discs = discs;
        _pegs = new[] { new List<int>(), new List<int>(), new List<int>() };
        for (int d = discs; d >= 1; d--) _pegs[0].Add(d);
        Invalidate();
    }

    public void MoveDisc(int fromPeg, int toPeg)
    {
        var source = _pegs[fromPeg];
        if (source.Count == 0) return;
        int d = source[^1];
        source.RemoveAt(source.Count - 1);
        _pegs[toPeg].Add(d);
        Invalidate();
    }

    static Color Hsv(double h, double s, double v)
    {
        double f = h / 60 - Math.Floor(h / 60);
        int hi = (int)(h / 60) % 6;
        int V = (int)(v * 255), P = (int)(v * (1 - s) * 255), Q = (int)(v * (1 - f * s) * 255), T = (int)(v * (1 - (1 - f) * s) * 255);
        return hi switch
        {
            0 => Color.FromArgb(V, T, P),
            1 => Color.FromArgb(Q, V, P),
            2 => Color.FromArgb(P, V, T),
            3 => Color.FromArgb(P, Q, V),
            4 => Color.FromArgb(T, P, V),
            _ => Color.FromArgb(V, P, Q)
        };
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(BackColor);

        float w = Width, h = Height;
        float baseY = h - 50;
        float pegH = Math.Max(100, h - 130);
        using var baseBrush = new SolidBrush(Color.SaddleBrown);
        using var pegBrush = new SolidBrush(Color.DimGray);
        using var font = new Font("Segoe UI", 12, FontStyle.Bold);
        using var fmt = new StringFormat { Alignment = StringAlignment.Center };

        g.FillRectangle(baseBrush, 20, baseY, w - 40, 12);

        for (int i = 0; i < 3; i++)
        {
            float cx = w * (2 * i + 1) / 6f;
            g.FillRectangle(pegBrush, cx - 4, baseY - pegH, 8, pegH);
            g.DrawString("ABC"[i].ToString(), font, Brushes.Black, cx, baseY + 16, fmt);

            float maxW = w / 3f - 24, minW = 36;
            float dh = Math.Min(28, (pegH - 10) / Math.Max(1, _discs));
            for (int k = 0; k < _pegs[i].Count; k++)
            {
                int d = _pegs[i][k];
                float dw = minW + (maxW - minW) * d / Math.Max(1, _discs);
                var rect = new RectangleF(cx - dw / 2, baseY - (k + 1) * dh, dw, dh - 2);
                using var br = new SolidBrush(Hsv(300.0 * d / Math.Max(1, _discs), 0.65, 0.95));
                g.FillRectangle(br, rect);
                g.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
            }
        }
    }
}
