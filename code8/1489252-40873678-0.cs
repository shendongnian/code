    public class iOSCustomMobilePageRenderer : PageRenderer
    {
    	public override void ViewWillAppear(bool animated) {
    		base.ViewWillAppear(animated);
    
    
    		if (ViewController != null && ViewController.ParentViewController != null && ViewController.ParentViewController.NavigationController != null) {
    
    			if (ViewController.ParentViewController.NavigationController.NavigationBar != null)
    				ViewController.ParentViewController.NavigationController.SetNavigationBarHidden(true, false);
    		}
    	}
    }
