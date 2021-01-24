    if (picker.SelectedIndex > -1 && response.domains[picker.SelectedIndex].authorization == true)
    {
        userNameEntry.IsVisible = false;
        passwordEntry.IsVisible = false;
        userLabel.IsVisible = false;
    }
    else
    {
        userNameEntry.IsVisible = true;
        passwordEntry.IsVisible = true;
        userLabel.IsVisible = true;
    }
