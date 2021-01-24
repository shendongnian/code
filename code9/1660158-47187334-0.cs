    long counter = 0;
    long total = image.Width * image.Height * (Color.White - Color.Black);
    for(int x = 0; x < image.Width; x++)
    {
        for(int y = 0; y < image.Height; y++)
        {
            var p1 = image.GetPixel(x, y);
            var p2 = otherImage.GetPixel(x, y);
            var g1 = ((p1.R + p1.G + p1.B) / 3);
            var g2 = ((p2.R + p2.G + p2.B) / 3);
            var distance = Math.Abs(g1 - g2);
            counter += distance;
        }
    }
    var similarity = 100 - ((counter / total) * 100);
