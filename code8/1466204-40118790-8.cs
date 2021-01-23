    protected override void OnElementChanged(VisualElementChangedEventArgs e)
    {
        base.OnElementChanged(e);
        var enableScrolling = e?.NewElement?.GetValue(Properties.EnableScrolling) as bool?;
        if (enableScrolling.HasValue)
        {
            var view = NativeView as UIKit.UIWebView;
            if (view != null)
            {
                view.ScrollView.ScrollEnabled = enableScrolling.Value;
                view.ScrollView.Bounces = enableScrolling.Value;
            }
        }
    }
