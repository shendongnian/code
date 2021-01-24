    private void OnContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        if (!args.InRecycleQueue && 
            args.ItemContainer is ListViewItem container && 
            args.Item is ISupportListViewItemBrushes brushes)
        {
            Helper.SetPointerOverBackground(container, brushes.PointerOverBrush);
        }
    }
