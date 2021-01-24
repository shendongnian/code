    private void btnPersonEdit_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Person selectedPerson = (Person)(dtgPersons.SelectedItem);
        if (selectedPerson != null)
        {
            selectedPerson.FirstName = txtIme.Text;
            selectedPerson.LastName = txtPrezime.Text;
            selectedPerson.Town = (Town)cmbTowns.SelectedItem;
            selectedPerson.TownId = selectedPerson.Town.Id;
            //Apply changes to a database
            Person lastUpdated = Controller.UpdatePerson(selectedPerson);
            dtgPersons.UnselectAll();
        }
    }
