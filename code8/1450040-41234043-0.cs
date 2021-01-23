    using UIKit;
    using MessageUI;
    using Foundation;
    
    using Xamarin.Forms;
    
    using SampleApp.iOS;
    
    [assembly: Dependency(typeof(DeepLinks_iOS))]
    namespace SampleApp.iOS
    {
    	public class DeepLinks_iOS : IDeepLinks
    	{
    		public void OpenStoreLink()
    		{
    			Device.BeginInvokeOnMainThread(() => UIApplication.SharedApplication.OpenUrl(new NSUrl("https://appsto.re/us/uYHSab.i")));
    		}
    
    		public void OpenFeedbackEmail()
    		{
    			MFMailComposeViewController mailController;
    
    			if (MFMailComposeViewController.CanSendMail)
    			{
    				mailController = new MFMailComposeViewController();
    
    				mailController.SetToRecipients(new string[] { "support@gmail.com" });
    				mailController.SetSubject("Email Subject String");
    				mailController.SetMessageBody("This text goes in the email body", false);
    
    				mailController.Finished += (object s, MFComposeResultEventArgs args) =>
    				{
    					args.Controller.DismissViewController(true, null);
    				};
    
    				var currentViewController = GetVisibleViewController();
    				currentViewController.PresentViewController(mailController, true, null);
    			}
    		}
    
    		public void OpenSettings()
    		{
    			Device.BeginInvokeOnMainThread(() => UIApplication.SharedApplication.OpenUrl(new NSUrl(UIApplication.OpenSettingsUrlString)));
    		}
    	
		    static UIViewController GetVisibleViewController()
    		{
	    		var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;
    			if (rootController.PresentedViewController == null)
	    			return rootController;
		    	if (rootController.PresentedViewController is UINavigationController)
			    {
				    return ((UINavigationController)rootController.PresentedViewController).TopViewController;
			    }
			     if (rootController.PresentedViewController is UITabBarController)
    			{
	    			return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;
		    	}
			    return rootController.PresentedViewController;
    		}
        }
    }
