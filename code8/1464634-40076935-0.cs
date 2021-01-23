      [assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
        namespace ButtonRendererDemo.iOS
        {
            class MainPageRenderer : PageRenderer
            {
        
                public override void ViewWillAppear(bool animated)
                {
                    View.Frame = new CoreGraphics.CGRect(View.Frame.X, View.Frame.Y + 100, View.Frame.Width, View.Frame.Height);
                }
            }
        }
