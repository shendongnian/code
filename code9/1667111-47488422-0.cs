    public string Name
    {
        get { return Customer.Name } // <-- Should be _Customer.Name
        set
        {
            Customer.Name = value; // <-- Should be _Customer.Name
            OnPropertyChanged("Name");
        }
    }      
