    using System;
    using System.Diagnostics;
    
    using UIKit;
    
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    
    [assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
    namespace YourNameSpace
    {
    	public class MainPageRenderer : TabbedRenderer
    	{
		    MainPage _page;
    		protected override void OnElementChanged(VisualElementChangedEventArgs e)
    		{
    			base.OnElementChanged(e);
    			if (e.NewElement != null)
    				_page = e.NewElement as MainPage;
    			else
    				_page = e.OldElement as MainPage;
    			try
    			{
                    if (ViewController is UITabBarController tabBarController)
    					tabBarController.ViewControllerSelected += OnTabbarControllerItemSelected;
    			}
    			catch (Exception exception)
    			{
    				Debug.WriteLine(exception);
    			}
    		}
    		void OnTabbarControllerItemSelected(object sender, UITabBarSelectionEventArgs eventArgs)
    		{
    			if (_page?.CurrentPage?.Navigation != null && _page.CurrentPage.Navigation.NavigationStack.Count > 0)
                {
    				Debug.WriteLine("Tab Tapped");
                    //Handle Tab Tapped
                }
    		}
        }
    }
