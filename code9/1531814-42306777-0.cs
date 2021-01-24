    NameEntry.Text = string.Empty;
    AgeEntry.Text = string.Empty;
    numberOfSavedData++;
    //your saving logic in your button click
    if (numberOfSavedData == numberOfPlayers) 
    {
        NameEntry.IsVisible = false;
        AgeEntry.IsVisible = false;
        //etc...
    }
