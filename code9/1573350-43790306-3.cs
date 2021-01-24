    public class SwipeWebViewRenderer : WebViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);
			var view = NativeView as UIWebView;
			var swipeBackRecognizer = new UISwipeGestureRecognizer(HandleSwipeBack);
			swipeBackRecognizer.Direction = UISwipeGestureRecognizerDirection.Right;
			view.AddGestureRecognizer(swipeBackRecognizer);
		}
		void HandleSwipeBack()
		{
			(Element as WebView).GoBack();
		}
	}
