    private void selectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string listViewName = ((ListView)sender).Name;
        if (listViewName == "listView1")
        {
            listView2.SelectedItem = null;
            listView3.SelectedItem = null;
            listView4.SelectedItem = null;
        }
        else if (listViewName == "listView3")
        {
            listView1.SelectedItem = null;
            listView2.SelectedItem = null;
            listView4.SelectedItem = null;
        }
        else if (listViewName == "listView4")
        {
            listView1.SelectedItem = null;
            listView2.SelectedItem = null;
            listView3.SelectedItem = null;
        }
        else if (listViewName == "listView2")
        {
            listView1.SelectedItem = null;
            listView3.SelectedItem = null;
            listView4.SelectedItem = null;
        }
    }
