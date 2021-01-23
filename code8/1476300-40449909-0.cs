    //Convert the listview to a normal list of strings
    var followerList = new List<string>();
    //add each listview item to a normal list
    foreach (ListViewItem Item in followerListView.Items) {
         followerList.Add(Item.Text.ToString());
    }
    //create string collection from list of strings
    StringCollection collection = new StringCollection();
    //set the collection setting (created in Settings.settings as a specialized collection)
    Properties.Settings.Default.followedUsersSettingsCollection = collection;
    //persist  the settings
    Properties.Settings.Default.Save();
