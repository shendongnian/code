    if (Properties.Settings.Default.followedUsersSettingsListView == null)
    {
        // adding default items to settings 
        Properties.Settings.Default.followedUsersSettingsListView = new System.Collections.Specialized.StringCollection();
        Properties.Settings.Default.followedUsersSettingsListView.AddRange(new string [] {"Item1", "Item2"});
        Properties.Settings.Default.Save();
    }
    // load items from settings 
    followerList.Items.AddRange((from i in Properties.Settings.Default.followedUsersSettingsListView.Cast<string>()
                                        select new ListViewItem(i)).ToArray());
