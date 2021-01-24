    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;
    
        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            window = new UIWindow (UIScreen.MainScreen.Bounds);
            window.RootViewController = new UIViewController ();
            window.MakeKeyAndVisible ();
            
            return true;
        }
    }
