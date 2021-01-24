    public void AssignDelegates()
    {
        if (parisButton.IsPressed)
        {
            Apts apartments = new Apts();
            myFunc = DelActions.ListParis(apartments.Apartments);
        }
    }
