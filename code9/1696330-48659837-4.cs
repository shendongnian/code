    List<string> steden = new List<string>();
    var selectedLanden = landenList.FirstOrDefault(x => x.Naam == landenListBox.SelectedItem);
    if(selectedLanden != null)
    {
        foreach(var stad in selectedLanden.Steden)
        {
            steden.Add(stad.Naam);
        }
    }
    stedenInLandenListBox.ItemsSource = steden.ToList();
