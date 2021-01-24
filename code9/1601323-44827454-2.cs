    static void Main(string[] args)
    {
        Bitmap bitmap = new Bitmap("C:\\Users\\erik\\test.png");
    
        bitmap = Blur(bitmap, 5);
    
        bitmap.Save("C:\\Users\\erik\\test2.png");
    }
    
    private static Bitmap Blur(Bitmap image, Int32 blurSize)
    {
        return Blur(image, new Rectangle(0, 0, image.Width, image.Height), blurSize);
    }
    
    private static Bitmap Blur(Bitmap image, Rectangle rectangle, Int32 blurSize)
    {
        Bitmap blurred = new Bitmap(image.Width, image.Height);
    
        // make an exact copy of the bitmap provided
        using (Graphics graphics = Graphics.FromImage(blurred))
            graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
    
        // look at every pixel in the blur rectangle
        for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
        {
            for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
            {
                int avgR = 0, avgG = 0, avgB = 0;
                int blurPixelCount = 0;
    
                // average the color of the red, green and blue for each pixel in the
                // blur size while making sure you don't go outside the image bounds
                for (int x = xx; (x < xx + blurSize && x < image.Width); x++)
                {
                    for (int y = yy; (y < yy + blurSize && y < image.Height); y++)
                    {
                        Color pixel = blurred.GetPixel(x, y);
    
                        avgR += pixel.R;
                        avgG += pixel.G;
                        avgB += pixel.B;
    
                        blurPixelCount++;
                    }
                }
    
                avgR = avgR / blurPixelCount;
                avgG = avgG / blurPixelCount;
                avgB = avgB / blurPixelCount;
    
                // now that we know the average for the blur size, set each pixel to that color
                for (int x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                    for (int y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                        blurred.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
            }
        }
    
        return blurred;
    }
