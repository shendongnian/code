        int[] BData = new int[4] { 255, 11, 255, 0 };
        int width = 640;
        int height = 480;
        using (System.Drawing.Image IG = new System.Drawing.Bitmap(width, height))
        {
            using (System.Drawing.Graphics myGraphic = System.Drawing.Graphics.FromImage(IG))
            {
                System.Drawing.Color c = System.Drawing.Color.FromArgb((byte)BData[0], (byte)BData[1], (byte)BData[2], (byte)BData[3]); // int[] BData
                myGraphic.Clear(c);
            }
            IG.Save("test.png", System.Drawing.Imaging.ImageFormat.Png);
        }
