    private void PUDSPinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
    {
        Spinner spinner = (Spinner)sender;
    
        var item = spinner.GetItemAtPosition (e.Position);
        string selected = item.ToString();
    }
