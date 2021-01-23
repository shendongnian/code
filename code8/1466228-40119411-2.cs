		public Restaurant SelectedRestaurant
		{
			get;
			set;
		}
        UIWebView webView;
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			webView = new UIWebView(View.Bounds);
			View.AddSubview(webView);
			if (SelectedRestaurant != null)
			{
				var url = SelectedRestaurant.Website;
			    webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
            }
		}
