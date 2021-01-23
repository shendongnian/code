    public class MyListView : ListView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DesignerItem();
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DesignerItem;
        }
    }
    public class DesignerItem : ListViewItem
    {
        public bool IsEditing
        {
            get { return (bool)GetValue(IsEditingProperty); }
            set { SetValue(IsEditingProperty, value); }
        }
        public static readonly DependencyProperty IsEditingProperty =
            DependencyProperty.Register("IsEditing", typeof(bool), typeof(DesignerItem));
    }
