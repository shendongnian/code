     public Bitmap MakeSquarePhoto(Bitmap bmp, int size)
            {
                try
                {
                    Bitmap res = new Bitmap(size, size);
                    Graphics g = Graphics.FromImage(res);
                    g.FillRectangle(new SolidBrush(Color.White), 0, 0, size, size);
                    int t = 0, l = 0;
                    if (bmp.Height > bmp.Width)
                        t = (bmp.Height - bmp.Width) / 2;
                    else
                        l = (bmp.Width - bmp.Height) / 2;
                    g.DrawImage(bmp, new Rectangle(0, 0, size, size), new Rectangle(l, t, bmp.Width - l * 2, bmp.Height - t * 2), GraphicsUnit.Pixel);
                    return res;
                }
                catch { }
            }
