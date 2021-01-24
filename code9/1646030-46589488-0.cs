    public class MainTabPageRenderer : TabbedRenderer
    {
        private UIKit.UITabBarItem _prevItem;
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            if (SelectedIndex < TabBar.Items.Length)
                _prevItem = TabBar.Items[SelectedIndex];
        }
        public override void ItemSelected(UIKit.UITabBar tabbar,
                                          UIKit.UITabBarItem item)
        {
            if (_prevItem == item && Element is MainPage)
            {
                // the same tab was selected a second time, so do something
            }
            _prevItem = item;
        }
    }
