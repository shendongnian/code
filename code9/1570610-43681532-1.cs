            Bitmap myBitmap = new Bitmap(pictureBox1.Image);
            //pictureBox1_Paint.Image = bmp;
            // Draw myBitmap to the screen.
            e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width, myBitmap.Height);
            Color pix;
            Color pixx;
            for (int X = 1; X < myBitmap.Width-1; X++)
            {
                for (int Y = 1; Y < myBitmap.Height-1; Y++)
                {
                    pix = myBitmap.GetPixel(X, Y);
                    pixx = myBitmap.GetPixel(X, Y);
                    Color pixwhite = myBitmap.GetPixel(X, Y);
                    Color pixelColor = myBitmap.GetPixel(X - 1, Y - 1);
                    if (pix.R > 150 && pix.G > 150 && pix.B > 150)
                    {
                        Color myWhite = new Color();
                        Color myColor = new Color();
                        myWhite = Color.FromArgb(pix.R, pix.G, pix.B);
                        if (pixx.R < 150 && pixx.G < 150 && pixx.B < 150)
                        {
                            myColor = Color.FromArgb(pixx.R, pixx.G, pixx.B);
                            if (pixwhite != pixelColor)
                            {
                                myBitmap.SetPixel(X, Y, myColor);
                            }
                           
                        }
                        Color newcolor = new Color();
                        newcolor = Color.FromArgb(Math.Abs(pix.R - pixx.R) + Math.Abs(pix.G - pixx.G) + Math.Abs(pix.B - pixx.B));
                    }
                    //else
                    //{  //myBitmap.SetPixel(X, Y, pix);
                     //   Color nearc = myBitmap.GetPixel(X, Y);
                    //    myBitmap.SetPixel(X, Y, nearc);
                    //}
                }
            }
            // Draw myBitmap to the screen again.
            e.Graphics.DrawImage(myBitmap, myBitmap.Width, 0, myBitmap.Width, myBitmap.Height);
        }
