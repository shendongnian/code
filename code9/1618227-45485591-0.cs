    using Android.Support.Design.Widget;
    using App1;
    using App1.Droid;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android.AppCompat;
    
    [assembly: ExportRenderer(typeof(ScrollableTabbedPage), typeof(ScrollableTabbedPageRenderer))]
    namespace App1.Droid
    {
        public class ScrollableTabbedPageRenderer : TabbedPageRenderer
        {
            public override void OnViewAdded(Android.Views.View child)
            {
                base.OnViewAdded(child);
                var tabLayout = child as TabLayout;
                if (tabLayout != null)
                {
                    tabLayout.TabMode = TabLayout.ModeScrollable;
                }
            }
    
        }
    }
