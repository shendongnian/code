    private void landenListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        using (var entities = new LandenStedenTalenEntities())
        {
            List<string> steden = new List<string>();
            var landcode = ((Landen)landenListBox.SelectedItem).LandCode;
            var gekozenland = entities.Landen.Find(landcode);
            foreach(var stad in gekozenland.Steden)
            {
                steden.Add(stad.Naam);
            }
            stedenInLandenListBox.ItemsSource = steden.ToList();
        }
    }
