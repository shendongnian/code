        private void OnListViewContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (args.ItemContainer != null && !args.InRecycleQueue && args.Phase == 0)
            {
                args.ItemContainer.IsSelected = ((JobStatusItem)args.Item).Selected;
