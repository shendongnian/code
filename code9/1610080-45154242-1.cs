    private void zoom_Click(object sender, EventArgs e)
    {
        PictureBox canvas = pictureBox1;
        Panel frame = panel1;
        // Se new zoom level, depending on the button
        float zoom = sender == btn_ZoomIn ? 2f : 0.5f;
        // calculate old ratio:
        float ratio = 1f * canvas.ClientSize.Width / canvas.Image.Width;
        // calculate frame fixed pixel:
        Point fFix = new Point( frame.Width / 2,  frame.Height / 2);
        // calculate the canvas fixed pixel:
        Point cFix =  new Point(-canvas.Left + fFix.X, -canvas.Top + fFix.Y );
        // calculate the bitmap fixed pixel:
        Point iFix = new Point((int)(cFix.X / ratio),(int)( cFix.Y / ratio));
        // do the zoom
        canvas.Size = new Size( (int)(canvas.Width *  zoom), (int)(canvas.Height *  zoom) );
        // calculate new ratio:
        float ratio2 = 1f * canvas.ClientSize.Width / canvas.Image.Width;
        // calculate the new canvas fixed pixel:
        Point cFix2 = new Point((int)(iFix.X * ratio2),(int)( iFix.Y * ratio2));
        // move the canvas:
        canvas.Location = new Point(-cFix2.X + fFix.X, -cFix2.Y + fFix.Y);
    }
