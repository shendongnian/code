    public void SetCountry(Country country)
    {
        //assumung you have controls on your form for displaying the data:
        Text = country.Name;
        txtDescription.Text = country.Description;
        txtHistory.Text = country.History;
        //etc.
    }
