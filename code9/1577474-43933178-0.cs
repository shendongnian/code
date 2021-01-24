        int searchRadius = bitmap.Width / 4;
        for (int X = 0; X < bitmap.Width - 3; X += 3)
        {
            for (int Y = 0; Y < bitmap.Height - 3; Y += 3)
            {
                Color pix = bitmap.GetPixel(X, Y);
                for (int l = 0; l < 3; l++)
                {
                    for (int m = 0; m < 3; m++)
                    {
                        int a = random.Next(bitmap.Width);
                        int b = random.Next(bitmap.Height);
                        Color rndcolor = bitmap.GetPixel(a, b);
                        if (rndcolor.R > 175 && rndcolor.G > 175 && rndcolor.B > 175)
                        {
                            int minR = 255;
                            int minG = 255;
                            int minB = 255;
                            Point findedPoint = new Point();
                            for (int X1 = X- searchRadius; X1 < (X + searchRadius)% (bitmap.Width - 3); X1 += 3)
                            {
                                for (int Y1 = 0; Y1 < (Y + searchRadius) % (bitmap.Height - 3); Y1 += 3)
                                {
                                    Color searchColor = bitmap.GetPixel(a, b);
                                    if (Math.Abs(searchColor.R - rndcolor.R) < minR &
                                        Math.Abs(searchColor.B - rndcolor.B) < minB &
                                        Math.Abs(searchColor.G - rndcolor.G) < minG)
                                    {                                                                                    
                                        minR = Math.Abs(searchColor.R - rndcolor.R);
                                        minB = Math.Abs(searchColor.B - rndcolor.B);
                                        minG = Math.Abs(searchColor.G - rndcolor.G);
                                        findedPoint.X = X1;
                                        findedPoint.Y = Y1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
