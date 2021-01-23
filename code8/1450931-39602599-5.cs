    private void chart7_Paint(object sender, PaintEventArgs e)
    {
        Axis ay = chart7.ChartAreas[0].AxisY;
        Graphics g = e.Graphics;
        g.TranslateTransform(-20, 180);
        g.RotateTransform(270);
        using (SolidBrush brush = new SolidBrush(ay.TitleForeColor))
            g.DrawString(ay.Title, ay.TitleFont, brush, 22, 22);
    }
