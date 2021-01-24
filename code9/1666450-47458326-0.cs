    public void Draw()
    {
        var bitmap = new Bitmap(640, 480);
            
        for (var x = 0; x < bitmap.Width; x++)
        {
            for (var y = 0; y < bitmap.Height; y++)
            {
                bitmap.SetPixel(x, y, Color.BlueViolet);
            }
       }
    
       bitmap.Save("m.bmp");
    }
