    Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(UserSettings_PropChanged);
    private void UserSettings_PropChanged(object sender, PropertyChangedEventArgs e)
    {
        //update the form's display properties
        //e.g.
        this.ForeColor = Properties.Settings.Default.FormForeColour;
        labelStatus = e.PropertyName + " successfully updated";
    }
