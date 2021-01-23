    private void SwipeListView_ItemSwipe(object sender, ItemSwipeEventArgs e)
    {
        var item = e.SwipedItem as EmailObject;
        if (item != null)
        {
            if (e.Direction == SwipeListDirection.Left)
            {
                item.Unread = !item.Unread;
            }
            else
            {
                //(Resources["Emails"] as EmailCollection).Remove(item);
                var swipeListView = sender as SwipeListView;
                var itemContainer = swipeListView?.ContainerFromItem(item) as SwipeListViewItem;
                if (itemContainer != null)
                {
                    itemContainer.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
