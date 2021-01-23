	public class WebViewRenderer_Droid : WebViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
		{
			if (e.NewElement == null)
				Console.WriteLine("*********e.NewElement is null");
			else
				Console.WriteLine("*********e.NewElement is not null");
			if (e.OldElement == null)
				Console.WriteLine("*********e.OldElement is null");
			else
				Console.WriteLine("*********e.OldElement is not null");
			if (Control == null)
				Console.WriteLine("*********Control is null");
			else
				Console.WriteLine("*********Control is not null");
			base.OnElementChanged(e);
		}
	}
