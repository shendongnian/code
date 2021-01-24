    private static SnippingTool _instance;
    public static SnippingTool GetInstance(Bitmap screen)
    {
        get
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new SnippingTool(screen);
            }
            return _instance;
        }
    }
