    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        // Default check: left mouse button only
        if (e.Button == MouseButtons.Left)
            ShowCoords(e.X, e.Y);
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        // Allows dragging to also update the coords. Checking the button
        // on a MouseMove is an easy way to detect click dragging.
        if (e.Button == MouseButtons.Left)
            ShowCoords(e.X, e.Y);
    }
    private void ShowCoords(Int32 mouseX, Int32 mouseY)
    {
        Int32 realW = pictureBox1.Image.Width;
        Int32 realH = pictureBox1.Image.Height;
        Int32 currentW = pictureBox1.ClientRectangle.Width;
        Int32 currentH = pictureBox1.ClientRectangle.Height;
        Double zoomW = (currentW / (Double)realW);
        Double zoomH = (currentH / (Double)realH);
        Double zoomActual = Math.Min(zoomW, zoomH);
        Double padX = zoomActual == zoomW ? 0 : (currentW - (zoomActual * realW)) / 2;
        Double padY = zoomActual == zoomH ? 0 : (currentH - (zoomActual * realH)) / 2;
        Int32 realX = (Int32)((mouseX - padX) / zoomActual);
        Int32 realY = (Int32)((mouseY - padY) / zoomActual);
        lblPosXval.Text = realX < 0 || realX > realW ? "-" : realX.ToString();
        lblPosYVal.Text = realY < 0 || realY > realH ? "-" : realY.ToString();
    }
