    enum DimensionType { Height, Width }
    public static class DisplayInfo
    {
       public static uint EffictivePixelHeight
       {
           get { return GetEffectivePixels(DimensionType.Height); }
       }
       public static uint EffectivePixelWidth
       {
           get { return GetEffectivePixels(DimensionType.Width); }
       }
       /// <summary>
       /// Calculate Effective Pixels based on RawPixelCount and ResolutionScale
       /// </summary>
       /// <param name="t">calculate width or height</param>
       /// <returns>0 if invalid, effecective pixel height/width based on t</returns>
       private static uint GetEffectivePixels(DimensionType t)
       {
           DisplayInformation info = DisplayInformation.GetForCurrentView();
           uint r = 0;
           switch (t)
           {
               case DimensionType.Height:
                   r = info.ScreenHeightInRawPixels;
                   break;
               case DimensionType.Width:
                   r = info.ScreenWidthInRawPixels;
                   break;
               default:
                   break;
           } 
           double scaleFactor = info.RawPixelsPerViewPixel;               
           r = (uint)(r * (1 / scaleFactor));  
           return r;
       }
    }
