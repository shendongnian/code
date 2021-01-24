    using Foundation;
    using Microsoft.Practices.Unity;
    using Prism.Unity;
    using UIKit;
    
    namespace XamPrismShared.iOS
    {	
    	[Register("AppDelegate")]
    	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    	{
    		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    		{
    			global::Xamarin.Forms.Forms.Init ();
    			LoadApplication (new XamPrismShared.App(new iOSPlatformInitializer()));
    
    			return base.FinishedLaunching (app, options);
    		}
    	}
    
        public class iOSPlatformInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IUnityContainer container)
            {
    
            }
        }
    }
