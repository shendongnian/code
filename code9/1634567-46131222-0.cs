    public AlternatingRowListView()
    {
        DefaultStyleKey = typeof(ListView);
        Items.VectorChanged += OnItemsVectorChanged;
    }
    private void OnItemsVectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs args)
    {
        // When an item is removed from the list...
        if (args.CollectionChange == CollectionChange.ItemRemoved)
        {
            var removedItemIndex = (int)args.Index;
            // We don't really care about the items that are above the deleted one, so the starting index
            // is the removed item's index.
            for (var i = removedItemIndex; i < Items.Count; i++)
            {
                if (ContainerFromIndex(i) is ListViewItem listViewItem)
                {
                    listViewItem.Background = i % 2 == 0 ? 
                        new SolidColorBrush(Colors.LightBlue) : new SolidColorBrush(Colors.Transparent);
                }
                // If it's null, it means virtualization is on and starting from this index the container
                // is not yet realized, so we can safely break the loop.
                else
                {
                    break;
                }
            }
        }
    }
