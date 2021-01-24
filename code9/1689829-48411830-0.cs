    private Point _MouseDownCoordinates;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        //selection.mouseDown(e);
        _MouseDownCoordinates = new Point(e.X, e.Y);
        pictureBox1.Refresh();
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        Int32 deltaX = e.X - _MouseDownCoordinates.X;
        Int32 deltaY = e.Y - _MouseDownCoordinates.Y;
        Rectangle rect = new Rectangle(_MouseDownCoordinates, new Size(deltaX, deltaY));
        var img = new Bitmap(deltaX, deltaY, PixelFormat.Format24bppRgb);
        using (var g = Graphics.FromImage(img))
        {
            g.CopyFromScreen(panel1.PointToScreen(_MouseDownCoordinates), new Point(0, 0), rect.Size);
            var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
            var page = ocr.Process(img);
            txtResult.Text = page.GetText();
         }
    }
