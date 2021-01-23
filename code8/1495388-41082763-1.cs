    public string CustomerName
    {
        get { return Customer.Name; }
        set
        {
            Customer.Name = value;
            NotifyOfPropertyChange(); // CallerMemberName goodness
            NotifyOfPropertyChange(() => CanUpdateClick);
        }
    }
