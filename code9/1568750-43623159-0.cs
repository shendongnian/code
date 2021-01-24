        private static async void TakeFullScreenShotAsync()
        {
            await Task.Delay(750);//Allows task to be waited on for .75ths of a second. Time In ms.
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            using (Bitmap screenshot = new Bitmap(width, height, PixelFormat.Format32bppArgb))
            {
                using (Graphics graphics = Graphics.FromImage(screenshot))
                {
                    System.Drawing.Point origin = new System.Drawing.Point(0, 0);
                    System.Drawing.Size screenSize = Screen.PrimaryScreen.Bounds.Size;
                    //Copy Entire screen to entire bitmap.
                    graphics.CopyFromScreen(origin, origin, screenSize);
                }
                //Check to see if the file exists, if it does, append.
                int append = 1;
                while (File.Exists($"Screenshot{append}.jpg"))
                    append++;
                string fileName = $"Screenshot{append}.jpg";
                screenshot.Save(fileName, ImageFormat.Jpeg);
                // Call the Show Tip Message Here...
                BalloonTip();
            }
        }
