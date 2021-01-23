    private static ViewController vc;
    public static WevViewController SharedInstance()
    		{
    			if (vc == null)
    			{
    				var storyboard = UIStoryboard.FromName("MainStoryboard", null);
    				vc = storyboard.InstantiateViewController("WevViewController") as WevViewController;
    
    			}
    			return vc;
    		}
