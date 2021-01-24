    private void deleteBtn_Click(object sender, RoutedEventArgs e)
    {
        HotelContext db = new HotelContext();
        Client client = clientDataGrid.SelectedItem as Client;
        try
        {
            _currentClient = db.Clients.Where(c => c.Id == client.Id).Single();
            db.Clients.Remove(_currentClient);
            db.SaveChanges();
            clientDataGrid.ItemsSource = null;
            clientDataGrid.ItemsSource = GETYOURCLIENTSFROMDATABASE();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
