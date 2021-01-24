    using Android.Support.Design.Widget;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using Xamarin.Forms.Platform.Android.AppCompat;
    [assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
    namespace YourNameSpace
    {
    	public class MainPageRenderer : TabbedPageRenderer, TabLayout.IOnTabSelectedListener
    	{
    		private MainPage _page;
    		protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
    		{
    			base.OnElementChanged(e);
    			if (e.NewElement != null)
    			{
    				_page = (MainPage)e.NewElement;
    			}
    			else
    			{
    				_page = (MainPage)e.OldElement;
    			}
    
    		}
    		async void TabLayout.IOnTabSelectedListener.OnTabReselected(TabLayout.Tab tab)
    		{
                //Perform logic for reselecting tab
    		}
    	}
    }
