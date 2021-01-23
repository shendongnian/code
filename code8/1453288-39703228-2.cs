    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Assign DataTemplate for selected items
            foreach (var item in e.AddedItems)
            {
                ListViewItem _lvi = item as ListViewItem;
                _lvi.ContentTemplate = (DataTemplate)this.Resources["dataTemplate1"];
            }
            //Remove DataTemplate for unselected items
            foreach (var item in e.RemovedItems)
            {
                ListViewItem _lvi = item as ListViewItem;
                _lvi.ContentTemplate = null;
            }
        }
