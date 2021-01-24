    public void OnButtonClick(object sender, EventArgs e)
    {
        if(sender is ApartmentDetails)
        {
            DisplayForm(new ApartmentDetails());
        }
        ...
    }
