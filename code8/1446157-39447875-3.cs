    Matrix matrix = null;
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        int height = pictureBox1.ClientSize.Height / 2;
        int width = pictureBox1.ClientSize.Width / 2;
        //=====
        //scale
        //=====
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.TranslateTransform(-width, -height);
        e.Graphics.ScaleTransform(2f, 2f);
        matrix = e.Graphics.Transform;   // save the transformation matrix!
        ...
