    public class ChromeDriverMobile : ChromeDriver, IHasTouchScreen
    {
            public ITouchScreen TouchScreen => new RemoteTouchScreen(this);
    
            public ChromeDriverMobile(Uri uri, ChromeOptions options) : base(uri, options)
            {
    
            }
    }
