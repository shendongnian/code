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
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var elem = element as DesignerItem;
            elem.ContentEditTemplate = ItemEditTemplate;
        }
        public DataTemplate ItemEditTemplate
        {
            get { return (DataTemplate)GetValue(ItemEditTemplateProperty); }
            set { SetValue(ItemEditTemplateProperty, value); }
        }
        public static readonly DependencyProperty ItemEditTemplateProperty =
            DependencyProperty.Register("ItemEditTemplate", typeof(DataTemplate), typeof(MyListView));
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
        public DataTemplate ContentEditTemplate
        {
            get { return (DataTemplate)GetValue(ContentEditTemplateProperty); }
            set { SetValue(ContentEditTemplateProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ContentEditTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentEditTemplateProperty =
            DependencyProperty.Register("ContentEditTemplate", typeof(DataTemplate), typeof(DesignerItem));
    }
