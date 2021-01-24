    public void spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e) {
        Spinner spinner = (Spinner)sender;
        string value = spinner.GetItemAtPosition(e.Position).ToString();
        //Use value ...
    
        //Reset spinner2
        spinner2.SetSelection(0);
    }
    
    public void spinner2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e) {
        Spinner spinner = (Spinner)sender;
        string value = spinner.GetItemAtPosition(e.Position).ToString();
        //Use value ...
    
        //Reset spinner1
        //spinner1.SetSelection(0);
    }
