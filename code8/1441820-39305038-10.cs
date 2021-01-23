    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.Fuchsia, 2.5f) { DashStyle = DashStyle.Dot})
            e.Graphics.DrawRectangle(pen, Rectangle.Round(ImgArea));
        e.Graphics.SetClip(ImgArea);
        e.Graphics.DrawLine(Pens.Red, scalePoint(mDown, false), scalePoint(mLast, false));
    }
