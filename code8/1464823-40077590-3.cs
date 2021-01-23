    public class CustomViewRenderer : ViewRenderer<CustomView, NativeView>
    {
        CustomView customView;
        NativeView nativeView;
        protected override void OnElementChanged(ElementChangedEventArgs<CustomView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                customView = e.NewElement as CustomView;
                nativeView = Control as NativeView;
                NativeView.CLicked += METHOD_CALLED_BY_EVENT;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
        private void METHOD_CALLED_BY_EVENT(object sender, EventArgs ea)
        {
            customView.MainPageCallback(ea.something.information);
        }
    }
