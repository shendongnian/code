    public class MyItemsControl : ItemsControl
    {
        static MyItemsControl()
        {
            ItemsSourceProperty.OverrideMetadata(
                typeof(MyItemsControl),
                new FrameworkPropertyMetadata(OnItemsSourcePropertyChanged));
        }
        private static void OnItemsSourcePropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ((MyItemsControl)obj).OnItemsSourcePropertyChanged(e);
        }
        private void OnItemsSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            var oldCollectionChanged = e.OldValue as INotifyCollectionChanged;
            var newCollectionChanged = e.NewValue as INotifyCollectionChanged;
            if (oldCollectionChanged != null)
            {
                oldCollectionChanged.CollectionChanged -= OnItemsSourceCollectionChanged;
            }
            if (newCollectionChanged != null)
            {
                newCollectionChanged.CollectionChanged += OnItemsSourceCollectionChanged;
                // in addition to adding a CollectionChanged handler
                // any already existing collection elements should be processed here
            }
        }
        private void OnItemsSourceCollectionChanged(
            object sender, NotifyCollectionChangedEventArgs e)
        {
            // handle collection changes here
        }
    }
