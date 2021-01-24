    static void Main(string[] args)
    {
        System.IO.Directory.CreateDirectory("output");
        using (var img = Image.Load("LPUVf.png"))
        using (var texture = Image.Load("stars.jpg"))
        {
            if (img.Width <=  texture.Width || img.Height <= texture.Height)
            {
                throw new InvalidOperationException("Image dimensions must be less than or equal to texture dimensions!");
            }
    
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    var pixel = img[x, y];
                    if (pixel == Rgba32.White)
                    {
                        img[x, y] = texture[x, y];
                    }
                }
            }
    
            img.Save("output/LBUVf.png");
        }
    }
