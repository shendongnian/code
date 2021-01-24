    byte highestRed = 0;
    using (var file = new FileStream(@"C:\mypath\mypicture.jpg", FileMode.Open))
    {
        Bitmap image = new Bitmap(file);
        for (int x = 0; x < image.Width; x++)
        {
            for (int y = 0; y < image.Height; y++)
            {
                var color = image.GetPixel(x, y);
                if(highestRed < color.R)
                    highestRed = color.R;
            }
        }
    }
