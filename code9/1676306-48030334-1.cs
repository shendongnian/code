        public class vmCustomers : DependencyObject, INotifyPropertyChanged 
        {
            protected ObservableCollection<Customer> _customers;
            public event PropertyChangedEventHandler PropertyChanged;
    
            public static DependencyProperty SelectedCustomerProperty =
                DependencyProperty.Register( "SelectedCustomer", typeof(Customer), typeof(vmCustomers),
                            new PropertyMetadata(default(Customer), new PropertyChangedCallback(OnSelectedCustomerChanged)));
    
            private static void OnSelectedCustomerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Customer value = (Customer)e.NewValue;
                vmCustomers vm = (vmCustomers)d;
    
                vm.OnPropertyChanged("SelectedCustomer");
            }
    
            public Customer SelectedCustomer
            {
                get { return (Customer)GetValue(SelectedCustomerProperty); }
                set { SetValue(SelectedCustomerProperty, value); }
            }
    
    
            public vmCustomers()
            {
                _customers = new ObservableCollection<Customer>();
    
                _customers.Add( new Customer() { CustomerID = 1, CustName = "John Doe" });
                _customers.Add(new Customer() { CustomerID = 2, CustName = "Johny Walker" });
                _customers.Add(new Customer() { CustomerID = 3, CustName = "Joe Foreman" });
                _customers.Add(new Customer() { CustomerID = 4, CustName = "Mike Tyson" });
                _customers.Add(new Customer() { CustomerID = 5, CustName = "Salvatore Ferragamo" });
                _customers.Add(new Customer() { CustomerID = 6, CustName = "Pato Donald" });
            }
    
            public ObservableCollection<Customer> Customers
            {
                get { return _customers; }
                set { _customers = value; }
            }
    
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(name));
            }
        }
    
        public class vmOrders : DependencyObject ,INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected ObservableCollection<Order> _AllOrders;
            protected ObservableCollection<Order> _CustomerOrders = null;
    
            public static DependencyProperty SelectedCustomerProperty =
                        DependencyProperty.Register( "SelectedCustomer", typeof(Customer), typeof(vmOrders),
                            new FrameworkPropertyMetadata(default(Customer), new PropertyChangedCallback(OnSelectedCustomerPropertyChanged)));
    
            private static void OnSelectedCustomerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Customer value = (Customer)e.NewValue;
                vmOrders vm = (vmOrders)d;
    
                vm.ApplyFilter();
                vm.OnPropertyChanged("Orders");
            }
    
            public Customer SelectedCustomer
            {
                get {return (Customer)GetValue(SelectedCustomerProperty); }
                set { SetValue(SelectedCustomerProperty, value); }
            }
    
            public vmOrders()
            {
                _AllOrders = new ObservableCollection<Order>();
    
                _AllOrders.Add(new Order() { OrderID = 1, CustomerID = 1, Date = System.DateTime.Parse("2017-01-01"), TotalAmount = 100 });
                _AllOrders.Add(new Order() { OrderID = 2, CustomerID = 1, Date = System.DateTime.Parse("2017-01-02"), TotalAmount = 200 });
                _AllOrders.Add(new Order() { OrderID = 3, CustomerID = 1, Date = System.DateTime.Parse("2017-01-03"), TotalAmount = 300 });
                _AllOrders.Add(new Order() { OrderID = 4, CustomerID = 1, Date = System.DateTime.Parse("2017-01-04"), TotalAmount = 400 });
                _AllOrders.Add(new Order() { OrderID = 5, CustomerID = 2, Date = System.DateTime.Parse("2017-01-05"), TotalAmount = 500 });
                _AllOrders.Add(new Order() { OrderID = 6, CustomerID = 2, Date = System.DateTime.Parse("2017-01-06"), TotalAmount = 600 });
                _AllOrders.Add(new Order() { OrderID = 7, CustomerID = 3, Date = System.DateTime.Parse("2017-01-07"), TotalAmount = 700 });
                _AllOrders.Add(new Order() { OrderID = 8, CustomerID = 3, Date = System.DateTime.Parse("2017-01-08"), TotalAmount = 800 });
                _AllOrders.Add(new Order() { OrderID = 9, CustomerID = 3, Date = System.DateTime.Parse("2017-01-09"), TotalAmount = 900 });
                _AllOrders.Add(new Order() { OrderID = 10, CustomerID = 3, Date = System.DateTime.Parse("2017-01-10"), TotalAmount = 1000 });
                _AllOrders.Add(new Order() { OrderID = 11, CustomerID = 3, Date = System.DateTime.Parse("2017-01-01"), TotalAmount = 1200 });
                _AllOrders.Add(new Order() { OrderID = 12, CustomerID = 3, Date = System.DateTime.Parse("2017-01-01"), TotalAmount = 1400 });
                _AllOrders.Add(new Order() { OrderID = 13, CustomerID = 4, Date = System.DateTime.Parse("2017-01-01"), TotalAmount = 1200 });
                _AllOrders.Add(new Order() { OrderID = 14, CustomerID = 4, Date = System.DateTime.Parse("2017-01-01"), TotalAmount = 5450 });
                _AllOrders.Add(new Order() { OrderID = 15, CustomerID = 4, Date = System.DateTime.Parse("2017-01-01"), TotalAmount = 5020 });
                _AllOrders.Add(new Order() { OrderID = 16, CustomerID = 4, Date = System.DateTime.Parse("2017-01-01"), TotalAmount = 5020 });
                _AllOrders.Add(new Order() { OrderID = 17, CustomerID = 5, Date = System.DateTime.Parse("2017-01-01"), TotalAmount = 5030 });
                _AllOrders.Add(new Order() { OrderID = 18, CustomerID = 5, Date = System.DateTime.Parse("2017-01-01"), TotalAmount = 5050 });
            }
    
            public void ApplyFilter()
            {
                if (SelectedCustomer != null)
                {
                    var linqresults = _AllOrders.Where(o => o.CustomerID == SelectedCustomer.CustomerID);
                    _CustomerOrders = new ObservableCollection<Order>(linqresults);
                }
                else
                {
                    _CustomerOrders = null;
                }
            }
            public ObservableCollection<Order> Orders
            {
                get {
                    if (SelectedCustomer != null)
                        return _CustomerOrders;
                    else
                        return _AllOrders;
                }
                set {
                    _AllOrders = value;
                    OnPropertyChanged("Orders");
                }
            }
    
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
