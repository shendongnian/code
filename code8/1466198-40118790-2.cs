    protected override void OnElementChanged(VisualElementChangedEventArgs e)
    {
        base.OnElementChanged(e);
        var disableScrolling = e?.OldElement?.GetValue(MainPage.DisableScrolling) as bool?;
        if (disableScrolling == true)
        {
            var view = NativeView as UIKit.UIWebView;
            if (view != null)
            {
                view.ScrollView.ScrollEnabled = false;
                view.ScrollView.Bounces = false;
            }
        }
    }
