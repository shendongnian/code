    [assembly:ExportRenderer(typeof(BottomTabbedView),typeof(BottomTabbedViewRenderer))]
    namespace PackageNameSpace.Droid
    {
        public class BottomTabbedViewRenderer:ViewRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
            {
                base.OnElementChanged(e);
                if (Control == null)
                {
                    // Instantiate the native control and assign it to the Control property with
                    // the SetNativeControl method
                    var context = Xamarin.Forms.Forms.Context;
                    LayoutInflater inflater = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                    var bottomnav_view = inflater.Inflate(Resource.Layout.bottomnav_view, this, false);
                    var frame = bottomnav_view.FindViewById<FrameLayout>(Resource.Id.rootLayout);
                    var navi = bottomnav_view.FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
                    SetNativeControl(bottomnav_view);
                }
    
                if (e.OldElement != null)
                {
                    // Unsubscribe from event handlers and cleanup any resources
                }
    
                if (e.NewElement != null)
                {
                    // Configure the control and subscribe to event handlers
                }
            }
        }
    }
