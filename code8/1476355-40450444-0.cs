       public void Blur(int blurSize, Bitmap input)
        {
            // look at every pixel in the blur rectangle
            for (int xx = 0; xx < input.Width; xx++)
            {
                for (int yy = 0; yy < input.Height; yy++)
                {
                    float avgR = 0;
                    float avgG = 0;
                    float avgB = 0;
                    float avgA = 0;
                    int blurPixelCount = 0;
                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (int x = xx; (x < xx + blurSize && x < input.Width); x++)
                    {
                        for (int y = yy; (y < yy + blurSize && y < input.Height); y++)
                        {
                            Color pixel = input.GetPixel(x, y);
                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;
                            avgA += pixel.A;
                            blurPixelCount++;
                        }
                    }
                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;
                    avgA = avgA / blurPixelCount;
                    // now that we know the average for the blur size, set each pixel to that color
                    for (int x = xx; x < xx + blurSize && x < input.Width; x++)
                    {
                        for (int y = yy; y < yy + blurSize && y < input.Height; y++)
                        {
                            input.SetPixel(x, y, Color.FromArgb((int)avgA, (int)avgR, (int)avgG, (int)avgB));
                        }
                    }
                }
            }
        }
