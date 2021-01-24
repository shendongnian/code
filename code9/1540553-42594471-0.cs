    private void ScreenCapture()
    {
        while (true)
        {
            var bm = new Bitmap((int)Math.Round(Screen.PrimaryScreen.Bounds.Width * 1.5), 
                               (int)Math.Round(Screen.PrimaryScreen.Bounds.Height * 1.5));
            using (Graphics g = Graphics.FromImage(bm)) g.CopyFromScreen(0, 0, 0, 0, bm.Size);
            this.pictureBox1.Image?.Dispose();
            this.pictureBox1.Image = bm;
            Thread.Sleep(250);
        }
    }
