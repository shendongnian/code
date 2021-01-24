    public class AlternatingListView : ListView
    {
        public static readonly DependencyProperty OddRowBackgroundProperty = DependencyProperty.Register(
            nameof(OddRowBackground),
            typeof(Brush),
            typeof(AlternatingListView),
            new PropertyMetadata(null));
    
        public static readonly DependencyProperty EvenRowBackgroundProperty = DependencyProperty.Register(
            nameof(EvenRowBackground),
            typeof(Brush),
            typeof(AlternatingListView),
            new PropertyMetadata(null));
    
        public Brush OddRowBackground
        {
            get { return (Brush)GetValue(OddRowBackgroundProperty); }
            set { SetValue(OddRowBackgroundProperty, (Brush)value); }
        }
    
        public Brush EvenRowBackground
        {
            get { return (Brush)GetValue(EvenRowBackgroundProperty); }
            set { SetValue(EvenRowBackgroundProperty, (Brush)value); }
        }
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
