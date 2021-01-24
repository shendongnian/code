    private void button_Click(object sender, RoutedEventArgs e)
    {
        using (var db = new ImperialFleetDBEntities())
        {
            listView.Items.Clear();
            foreach(var item in (from g in db.ShipsType select new { ID = g.ID, ShipType = g.ShipType }))
            {
                listView.Items.Add(item)
            }
        }
    }
