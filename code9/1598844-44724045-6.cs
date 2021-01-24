    #region EditCustomer Property
    public CustomerViewModel EditCustomer
    {
        get { return (CustomerViewModel)GetValue(EditCustomerProperty); }
        set { SetValue(EditCustomerProperty, value); }
    }
    public static readonly DependencyProperty EditCustomerProperty =
        DependencyProperty.Register(nameof(EditCustomer), typeof(CustomerViewModel), typeof(CustomerEditView),
            new FrameworkPropertyMetadata(null, EditCustomer_PropertyChanged));
    protected static void EditCustomer_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as MainWindow).OnEditCustomerChanged(e.OldValue);
    }
    private void OnEditCustomerChanged(object oldValue)
    {
        //  Or maybe your CustomerEditViewModel can acquire a new customer 
        //  to edit in some other way. 
        DataContext = new CustomerEditViewModel(EditCustomer);
    }
    #endregion EditCustomer Property
