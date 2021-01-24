    public List<string> FlatStringList = new List<string>();
    private void ListBox_SelectionChanged(object sender,System.Windows.Controls.SelectionChangedEventArgs e)
    {
        FlatStringList.AddRange(e.AddedItems.Cast<string>());
        foreach(string s in e.RemovedItems)
        {
            FlatStringList.Remove(s);
        }            
    }
