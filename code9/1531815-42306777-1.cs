    nameEntry.Text = string.Empty;
    ageEntry.Text = string.Empty;
    numberOfSavedData++;
    //click handler
    if (numberOfSavedData == numberOfPlayers)
    {
        EntriesStackLayout.Children.Remove(nameEntry);
        EntriesStackLayout.Children.Remove(ageEntry);
        //etc...
    }
