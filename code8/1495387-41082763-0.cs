    // in your view model
    // i'm assuming here that Customer is set before your view model is activated
    protected override void OnActivate()
    {
        base.OnActivate();
        Customer.PropertyChanged += CustomerPropertyChangedHandler;
    }
    protected override void OnDeactivate(bool close)
    {
        base.OnDeactivate(close);
        // unregister handler
        Customer.PropertyChanged -= CustomerPropertyChangedHandler;
    }
    // event handler
    protected void CustomerPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Customer.Name))
        {
            NotifyOfPropertyChange(() => CanUpdateClick);
        }
    }
