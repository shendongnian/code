    TransparentPanel overlay;
    TableLayoutPanel table;
    List<Point> points = new List<Point>();
    List<String> keys = new List<string>();
    public Form1()
    {
        overlay = new TransparentPanel() { Dock = DockStyle.Fill };
        this.Controls.Add(overlay);
        table = new TableLayoutPanel()
        { ColumnCount = 6, RowCount = 4, Dock = DockStyle.Fill };
        this.Controls.Add(table);
        var list = Enumerable.Range('A', 'Z' - 'A' + 1)
            .Select(x => ((char)x).ToString()).ToList();
        list.ForEach(x => table.Controls.Add(new Button()
        { Text = x, Width = 32, Height = 32 }));
        overlay.MouseDown += OverlayMouseDown;
        overlay.MouseMove += OverlayMouseMove;
        overlay.MouseUp += OverlayMouseUp;
        overlay.Paint += OverlayPaint;
    }
    void OverlayMouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            ProccessPoint(e.Location);
    }
    void OverlayMouseDown(object sender, MouseEventArgs e)
    {
        Clear();
        ProccessPoint(e.Location);
    }
    void OverlayMouseUp(object sender, MouseEventArgs e)
    {
        if (points.Count > 0)
            MessageBox.Show(string.Join(",", keys));
        Clear();
    }
    void OverlayPaint(object sender, PaintEventArgs e)
    {
        if (points.Count >= 3)
            e.Graphics.DrawCurve(Pens.Red, points.ToArray());
    }
    void ProccessPoint(Point p)
    {
        points.Add(p);
        var c = table.Controls.Cast<Control>()
            .Where(x => table.RectangleToScreen(x.Bounds)
            .Contains(overlay.PointToScreen(p))).FirstOrDefault();
        if ((c != null) && (keys.Count == 0 || keys[keys.Count - 1] != c.Text))
            keys.Add(c.Text);
        overlay.Invalidate();
    }
    void Clear()
    {
        keys.Clear();
        points.Clear();
        this.Refresh();
    }
