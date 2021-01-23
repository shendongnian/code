    private void selectionChanged1(object sender, SelectionChangedEventArgs e)
    {
        if(listView1.SelectedItem == null)
        {
            listView2.SelectedItem = null;
            listView3.SelectedItem = null;
            listView4.SelectedItem = null;
        }
    }
