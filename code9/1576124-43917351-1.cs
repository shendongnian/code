    Color32[] pixels = text.GetPixels32();
    Color blackTransparent = Color.black;
    
    for (int i = 0; i < pixels.Length; i += 4)
    {
        checkPixel(ref pixels[i], blackTransparent, Color.white, 600);
        checkPixel(ref pixels[i + 1], blackTransparent, Color.white, 600);
        checkPixel(ref pixels[i + 2], blackTransparent, Color.white, 600);
        checkPixel(ref pixels[i + 3], blackTransparent, Color.white, 600);
    }
    text.SetPixels32(pixels);
    text.Apply();
