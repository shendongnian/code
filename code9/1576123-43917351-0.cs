    Color32[] pixels = text.GetPixels32();
    Color blackTransparent = Color.black;
    Color overwriteColor = Color.white;
    
    blackTransparent.a = 0;
    for (int i = 0; i < pixels.Length; i += 4)
    {
        if (pixels[i] == blackTransparent)
            pixels[i] = overwriteColor;
    
    
        if (pixels[i + 1] == blackTransparent)
            pixels[i + 1] = overwriteColor;
    
    
        if (pixels[i + 2] == blackTransparent)
            pixels[i + 2] = overwriteColor;
    
    
        if (pixels[i + 3] == blackTransparent)
            pixels[i + 3] = overwriteColor;
    }
    text.SetPixels32(pixels);
    text.Apply(true);
