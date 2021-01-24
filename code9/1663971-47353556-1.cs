    private bool handleSelectionChanged = true;
    private void updateIdentite(Contact c, Dal dal)
    {
        ...
        handleSelectionChanged = false;
        idCivilite.SelectedValue = id.type_civilite;//example of a ComboBox
        handleSelectionChanged = true;
        ...
    }
    private void idCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (!handleSelectionChanged)
            return;
        //your code...
    }
