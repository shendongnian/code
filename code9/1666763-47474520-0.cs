    private void button2_Click(object sender, RoutedEventArgs e)
    {
        var selectedItem = listView.SelectedItem as ShipTypeClass;
        // Here's your ID, but you won't need it to remove the row in your database.
        var selectedShipID = selectedItem.Id;
        using (var db = new ImperialFleetDBEntities())
        {
            db.ShipsType.Attach(selectedItem);
            db.ShipsType.Remove(selectedItem);
            db.SaveChanges();
        }
    }
