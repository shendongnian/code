    public partial class AlternatingListView : ListView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            ListViewItem listViewItem = element as ListViewItem;
    
            if (listViewItem == null)
            {
                return;
            }
    
            int index = IndexFromContainer(element);
            listViewItem.Background = (index + 1) % 2 == 1 ? OddRowBackground : EvenRowBackground;
        }
    }
