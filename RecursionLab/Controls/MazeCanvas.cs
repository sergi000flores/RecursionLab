using System.Drawing.Drawing2D;

namespace RecursionLab.Controls;

public class MazeCanvas : Control
{
    private Bitmap _bmp;
    private int[,] _grid;
    private int _rows, _cols;

    static readonly Color Wall = Color.FromArgb(40, 44, 60);
    static readonly Color Floor = Color.White;
    static readonly Color Visited = Color.FromArgb(160, 205, 245);
    static readonly Color PathColor = Color.FromArgb(255, 140, 0);

    public MazeCanvas()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        BackColor = Color.FromArgb(235, 235, 240);
    }

    public void SetMaze(int[,] grid)
    {
        _grid = grid;
        _rows = grid.GetLength(0);
        _cols = grid.GetLength(1);
        _bmp?.Dispose();
        _bmp = new Bitmap(_cols, _rows);
        for (int r = 0; r < _rows; r++)
            for (int c = 0; c < _cols; c++)
                _bmp.SetPixel(c, r, grid[r, c] == 1 ? Wall : Floor);
        PaintEnds();
        Invalidate();
    }

    public void ClearSolution()
    {
        if (_grid != null) SetMaze(_grid);
    }

    void PaintEnds()
    {
        _bmp.SetPixel(1, 1, Color.LimeGreen);
        _bmp.SetPixel(_cols - 2, _rows - 2, Color.Crimson);
    }

    bool IsEnd(int r, int c) => (r == 1 && c == 1) || (r == _rows - 2 && c == _cols - 2);

    public void MarkVisited(int r, int c) { if (_bmp != null && !IsEnd(r, c)) _bmp.SetPixel(c, r, Visited); }
    public void MarkPath(int r, int c) { if (_bmp != null && !IsEnd(r, c)) _bmp.SetPixel(c, r, PathColor); }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(BackColor);
        if (_bmp == null) return;
        float scale = Math.Min((float)(Width - 20) / _cols, (float)(Height - 20) / _rows);
        if (scale <= 0) return;
        float w = _cols * scale, h = _rows * scale;
        g.InterpolationMode = InterpolationMode.NearestNeighbor;
        g.PixelOffsetMode = PixelOffsetMode.Half;
        g.DrawImage(_bmp, new RectangleF((Width - w) / 2, (Height - h) / 2, w, h));
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing) _bmp?.Dispose();
        base.Dispose(disposing);
    }
}
