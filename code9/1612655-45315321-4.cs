    using Android.Support.Design.Widget;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using Xamarin.Forms.Platform.Android.AppCompat;
    [assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
    namespace YourNameSpace
    {
    	public class MainPageRenderer : TabbedPageRenderer, TabLayout.IOnTabSelectedListener
    	{
		    MainPage _page;
    		protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
    		{
    			base.OnElementChanged(e);
    			if (e.NewElement != null)
    				_page = e.NewElement as MainPage;
    			else
    				_page = e.OldElement as MainPage;
    		}
    		void TabLayout.IOnTabSelectedListener.OnTabReselected(TabLayout.Tab tab)
    		{
                System.Diagnostics.Debug.WriteLine("Tab Reselected");
                //Handle Tab Reselected
    		}
    	}
    }
