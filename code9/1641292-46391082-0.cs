    public MainWindow()
    {
      InitializeComponent();
      var data = Enumerable.Range(1, 10)
        .Select(i =>
        new
        {
          Items = $"pur_Items{i}",
          Price = $"pur_Price{i}",
          Discount = $"pur_Discount{i}",
          ShippingCost = $"pur_Shipping{i}",
          Cost = $"pur_Total{i}"
        });
      dg.ItemsSource = data;
    }
