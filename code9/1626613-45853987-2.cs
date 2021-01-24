        public class MyListViewRenderer : ListViewRenderer
        {
            public UIView bar;
            protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
            {
                base.OnElementChanged(e);
    
                //Hide the default Scroll Indicator.
                Control.ShowsVerticalScrollIndicator = false;
    
    
                //Set Delegate
                CustomScrollDelegate customScrollDelegate = new CustomScrollDelegate();
                Control.Delegate = customScrollDelegate;
    
                //Create the background view of custom indicator.
                double frameHeight = Control.Frame.Size.Height;
                double frameWidth = Control.Frame.Size.Width;
                
                double barBackgroundWidth = 6;
                double statusBarHeight = 20;
    
                UIView barBackgroundView = new UIView();
                CGRect barBVRect = new CGRect(frameWidth - barBackgroundWidth, statusBarHeight, barBackgroundWidth, frameHeight);
                barBackgroundView.Frame = barBVRect;
                barBackgroundView.BackgroundColor = UIColor.Gray;
                barBackgroundView.Layer.CornerRadius = 2;
                barBackgroundView.Layer.MasksToBounds = true;
    
    
                //Create the bar of the custom indicator.
                bar = new UIView();
                CGRect barRect = new CGRect(1, 0, 4, 0);
                bar.Frame = barRect;
                bar.BackgroundColor = UIColor.Black;
                bar.Layer.CornerRadius = 2;
                bar.Layer.MasksToBounds = true;
    
                //Add the views to the superview of the tableview.
                barBackgroundView.AddSubview(bar);
                Control.Superview.AddSubview(barBackgroundView);
    
                //Transfer the bar view to delegate.
                customScrollDelegate.bar = bar;
    
            }
    
            public override void LayoutSubviews()
            {
                base.LayoutSubviews();
                Console.WriteLine("End of loading!!!");
                double contentHeight = Control.ContentSize.Height;
                double frameHeight = Control.Frame.Size.Height;
                double barHeight = frameHeight * frameHeight / contentHeight;
                
    
                //Reset the bar height when the table view finishes loading.
                CGRect barRect = new CGRect(bar.Frame.X, bar.Frame.Y, bar.Frame.Width, barHeight);
                bar.Frame = barRect;
            }
    
        }
