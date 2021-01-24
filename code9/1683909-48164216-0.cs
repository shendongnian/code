    private static SnippingTool instance;
    public static SnippingTool GetInstance(Bitmap screenShot)
    {
            if (instance == null || instance.IsDisposed)
            {
               instance = new SnippingTool(); 
            }
            instance.SetBitmap(screenShot) // if you need otherwise pass it to constructor
            return instance;
    }
