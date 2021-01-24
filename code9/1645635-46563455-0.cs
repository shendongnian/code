    // Declare this at the class global level
    Dictionary<string, Action> checkExecuter = new Dictionary<string, Action>();
    // Initialize it somewhere at the start of your class lifetime
    checkExecuter.Add("cbErbbstg", OnCbErbbstgChecked);
    // add other methods here
    checkExecuter.Add("cbAllBox", OnAllBox);
    
    // Action to execute when the cbErbbstg is checked
    void OnCbErbbstgChecked()
    {
        month = Months[idxMonth];
        LinkToRSS.Add(link + month);
        RSSname.Add(name);
        Picture.Add(picture);
        ID.Add(100);
    }
    // Action to execute when the cbAllBox is checked
    void onAllBox()
    {
       foreach(KeyValuePair<string, Action> kvp in checkExecuter)
       {
            if(kvp.Key != "cbAllBox")
               kvp.Value.Invoke();
       }
    }
    
    private void cbJournal_CheckedChanged(object sender, RoutedEventArgs e)
    {
       CheckBox chk = (CheckBox)sender;
       if (chk.IsChecked && checkExecuter.ContainsKey(chk.Name))
       { 
           checkExecuter[chk.Name].Invoke();
       }
    }
