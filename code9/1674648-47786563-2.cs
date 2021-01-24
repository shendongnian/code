    static void Main(string[] args)
    {
        System.IO.Directory.CreateDirectory("output");
        const int min = 128; // Grey midpoint
        using (var img = Image.Load("LPUVf.png"))
        using (var texture = Image.Load("stars.jpg"))
        {
            if (img.Width != texture.Width || img.Height != texture.Height)
            {
                throw new InvalidOperationException("Image dimensions must match!");
            }
    
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    var pixel = img[x, y];
                    if (pixel.R >= min && pixel.G >= min && pixel.B >= min && pixel.A >= min)
                    {
                        img[x, y] = texture[x, y];
                    }
                }
            }
    
            img.Save("output/LBUVf.png");
        }
    }
