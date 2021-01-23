    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        salesOrder = new SalesOrder();
        dgSaleItems.ItemsSource = salesOrder.Items;
        salesOrder.Items.CollectionChanged += (s, args) =>
        {
            if (args.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Item item in args.OldItems)
                {
                    item.PropertyChanged -= UpdateTotalSale;
                }
            }
            else if (args.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Item item in args.NewItems)
                {
                    item.PropertyChanged += UpdateTotalSale;
                }
            }
        };
    }
    private void UpdateTotalSale(object sender, PropertyChangedEventArgs e)
    {
        tbx_totalSale.Text = salesOrder.CalculateTotalPrice().ToString();
    }
