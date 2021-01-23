    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count != 0)
        {
            if (listView1 != sender as ListView) listView1.SelectedItem = null;
            if (listView2 != sender as ListView) listView2.SelectedItem = null;
            if (listView3 != sender as ListView) listView3.SelectedItem = null;
            if (listView4 != sender as ListView) listView4.SelectedItem = null;
        }
    }
