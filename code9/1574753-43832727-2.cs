    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            var items = listView.ItemsSource as IList<MasterPageItem>;
            //Select current item and deselect others
            for(int i = 0; i<items.Count; i++)
                items[i].IsActive = items[i] == item;
            if (item != null)
            {
                ItemSelected?.Invoke(this, item.TargetType);
                _activePage = item.TargetType;
            }
        }
