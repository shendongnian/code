    public class ExtendedListView : ListView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ExtendedListViewItem();
        }
    }
