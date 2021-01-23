    void DrawStuff(Bitmap bmp)
    {
        using (Graphics g = Graphics.FromImage(bmp))
        {
            // draw your stuff
            g.DrawRectangle(...);
        }
        // when done maybe assign it back into a Control..
        pictureBox.Image = bmp;
    }
