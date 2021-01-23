    //check for null (first run)
    if (Properties.Settings.Default.followedUsersSettings != null) {
        //create a new collection again
        StringCollection collection = new StringCollection();
        //set the collection from the settings variable
        collection = Properties.Settings.Default.followedUsersSettingsCollection;
        //convert the collection back to a list
        List<string> followedList = collection.Cast<string>().ToList();
        //populate the listview again from the new list
        foreach (var item in followedList) {
            followerListView.Items.Add(item);
        }
    }
