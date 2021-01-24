    private void ScreenCapture()
    {
        while (true)
        {
            var bm = new Bitmap((int)Math.Round(Screen.PrimaryScreen.Bounds.Width * 1.5), 
                               (int)Math.Round(Screen.PrimaryScreen.Bounds.Height * 1.5));
            using (Graphics g = Graphics.FromImage(bm)) g.CopyFromScreen(0, 0, 0, 0, bm.Size);
            
            // As per the comment by HansPassant - the following would cause
            // a thread race with the UI thread.
            //this.pictureBox1.Image?.Dispose();
            //this.pictureBox1.Image = bm;
            // Instead we use beginInvoke to run this on the UI thread
            Action action = () =>
                {
                    this.pictureBox1.Image?.Dispose();
                    this.pictureBox1.Image = bm;
                };
            this.BeginInvoke(action);
            Thread.Sleep(250);
        }
    }
