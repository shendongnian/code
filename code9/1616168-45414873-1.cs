    private void chatUI_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListView view = (ListView)sender;
        //Get Selected Item
        ClassName class = view.SelectedItem as ClassName;
        string path = class.Text;
     // Now we have Text of selected item in Listview 
    }
