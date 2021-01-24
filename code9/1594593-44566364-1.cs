    private void pictureBox5_Paint(object sender, PaintEventArgs e)
    {
        if (points.Count > 1)
        {
            Point center = new Point(
                (points.Select(x => x.X).Max() + points.Select(x => x.X).Min()) / 2,
                (points.Select(x => x.Y).Max() + points.Select(x => x.Y).Min()) / 2);
            e.Graphics.TranslateTransform(center.X, center.Y);
            e.Graphics.RotateTransform(angle);
            e.Graphics.TranslateTransform(-center.X, -center.Y);
            e.Graphics.DrawPolygon(Pens.DarkGreen, points.ToArray());
        }
    }
