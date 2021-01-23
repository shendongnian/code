    public static Bitmap ResizeImage(Bitmap bmp, int width, int height)
    {
        return bmp;
    }
    
    static void Main(string[] args)
    {
        var imageslist = Directory.EnumerateFiles("C:\\BmpTest", "*.bmp", SearchOption.AllDirectories)
            .AsParallel()
            .Select(path =>
                {
                    Bitmap ret = null;
                    try
                    {
                        ret = new Bitmap(path);
                    }
                    catch (Exception exc)
                    {
                         // put breakpoint here and check path
                    }
                    return ret;
                })
            .Select(bmp => ResizeImage(bmp, 100, 100))
            .ToList();
