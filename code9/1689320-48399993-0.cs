    public class MyTabControl : TabControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MyTabItem();
        }
    }
