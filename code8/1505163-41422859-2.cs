    private static ViewController vc;
    public static WebViewController SharedInstance()
    {
        if (vc == null)
        {
            var storyboard = UIStoryboard.FromName("MainStoryboard", null);
            vc = storyboard.InstantiateViewController("WevViewController") as WevViewController;
        }
        return vc;
    }
