    [assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
    namespace TabbedPageWithNavigationPage.iOS
    {
        class CustomTabbedPageRenderer : TabbedRenderer
        {
            public UIImage imageWithColor(CGSize size)
            {
                CGRect rect = new CGRect(0, 0, size.Width, size.Height);
                UIGraphics.BeginImageContext(size);
                using (CGContext context = UIGraphics.GetCurrentContext())
                {
                    context.SetFillColor(UIColor.Red.CGColor);
                    context.FillRect(rect);
                }
                UIImage image = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();
                return image;
            }
            public override void ViewWillAppear(bool animated)
            {
                base.ViewWillAppear(animated);
                CGSize size = new CGSize(TabBar.Frame.Width / TabBar.Items.Length, TabBar.Frame.Height);
                //Background Color
                UITabBar.Appearance.SelectionIndicatorImage = imageWithColor(size);
                //Normal title Color
                UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White }, UIControlState.Normal);
                //Selected title Color
                UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.Black }, UIControlState.Selected);
            }
        }
    }
