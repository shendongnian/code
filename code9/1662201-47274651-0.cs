    private void PopulateListView()
    {
        var l = GetPeople();
        txtJson.Text = JsonConvert.SerializeObject(l);
        LvIssues.ItemsSource= l;
    }
