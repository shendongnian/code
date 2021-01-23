	using System;
	using NameSpaceForMyiOSApp;
	using Xamarin.Forms;
	using Xamarin.Forms.Platform.iOS;
	[assembly: ExportRenderer(typeof(Button), typeof(MyButtonRenderer))]
	namespace NameSpaceForMyiOSApp
	{
		public class MyButtonRenderer : ButtonRenderer
		{
			protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
			{
				base.OnElementChanged(e);
				if (Control != null)
					Control.TitleLabel.LineBreakMode = UIKit.UILineBreakMode.WordWrap;
			}
		}
	}
