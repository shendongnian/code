    private void contactsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DataGrid ThisGrid = (DataGrid)sender;            
        Contact SelectedContact = (Contact)ThisGrid.SelectedItem;
        SelectedContact.IsSelected = true;
        contactsDataGrid.Items.Refresh();
        if (!SelectedContacts.Contains(SelectedContact))
            SelectedContacts.Add(SelectedContact);
    }
