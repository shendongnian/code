     public static Bitmap RtbToBitmap(RichTextBox rtb)
            {
                rtb.Update(); // Ensure RTB fully painted
                Bitmap bmp = new Bitmap(rtb.Width, rtb.Height);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.CopyFromScreen(rtb.PointToScreen(Point.Empty), Point.Empty, rtb.Size);
                }
                return bmp;
            }
