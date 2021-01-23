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
            MyItemsControl ic = obj as MyItemsControl;
            if (ic != null)
            {
                var oldCollectionChanged = e.OldValue as INotifyCollectionChanged;
                var newCollectionChanged = e.NewValue as INotifyCollectionChanged;
                if (oldCollectionChanged != null)
                {
                    oldCollectionChanged.CollectionChanged -= ic.OnItemsCollectionChanged;
                }
                if (newCollectionChanged != null)
                {
                    newCollectionChanged.CollectionChanged += ic.OnItemsCollectionChanged;
                    // in addition to adding a CollectionChanged handler
                    // any already existing collection elements should be processed here
                }
            }
        }
        private void OnItemsCollectionChanged(
             object sender, NotifyCollectionChangedEventArgs e)
        {
            // handle collection changes here
        }
    }
