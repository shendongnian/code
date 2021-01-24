        public class CustomScrollDelegate : UIKit.UITableViewDelegate
        {
            public UIView bar;
            double barY;
    
            public override void Scrolled(UIScrollView scrollView)
            {
                double y = scrollView.ContentOffset.Y;
                double contentHeight = scrollView.ContentSize.Height;
                double frameHeight = scrollView.Frame.Size.Height;
    
                double barHeight = frameHeight * frameHeight / contentHeight;
                barY = y / (contentHeight - frameHeight) * (frameHeight - barHeight);
    
                //Cut the bar Height when it over the top.
                if (barY < 0)
                {
                    barHeight = barHeight + barY;
                    barY = 0;
                }
    
                //Cut the bar height when it over the bottom.
                if (barY > (contentHeight - frameHeight))
                {
                    barHeight = barHeight - (barY - (contentHeight - frameHeight));
                }
    
                //Reset the barView rect. Let's move!!!
                CGRect barRect = new CGRect(bar.Frame.X, barY, bar.Frame.Width, barHeight);
                bar.Frame = barRect;
                
            }
    
        }
