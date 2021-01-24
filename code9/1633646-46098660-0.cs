    year_pk.SelectedIndexChanged += delegate 
    {
    int term = Int32.Parse(term_pk.SelectedItem.ToString());
    //Below  is my method am Firing Each change of the Picker.
                        OnResultsList(year_pk.SelectedItem.ToString(), term);
    }
    
    term_pk.SelectedIndexChanged += delegate 
    {
    int term = Int32.Parse(term_pk.SelectedItem.ToString());
    //Below  is my method am Firing Each change of the Picker.
                        OnResultsList(year_pk.SelectedItem.ToString(), term);
    }
