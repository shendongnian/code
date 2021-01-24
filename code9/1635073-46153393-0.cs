    public static int DarkenColor1(int oleColor, float sngRatio)
    {
        int R= oleColor & 255;
        int G= (int)(((long)oleColor & 65280L) / 256L);
        int B= (oleColor & 16711680) / 65536;               
        //return Information.RGB((int)(R / sngRatio), (int)(G / sngRatio), (int)(B / sngRatio)); 
        return ColorTranslator.ToOle(Color.FromArgb((int)(R / sngRatio), (int)(G / sngRatio), (int)(B / sngRatio));            
}
