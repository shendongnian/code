    public class MyListView : ListView
    {
        public string ItemIsSelectedPropertyName { get; set; } = "IsSelected";
        protected override void PrepareContainerForItemOverride(
            DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            BindingOperations.SetBinding(element,
                ListViewItem.IsSelectedProperty,
                new Binding
                {
                    Path = new PropertyPath(ItemIsSelectedPropertyName),
                    Source = item,
                    Mode = BindingMode.TwoWay
                });
        }
    }
