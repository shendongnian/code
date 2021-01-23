      public decimal TotalSale
      {
          get { return items.Sum(i => i.TotalPrice); }
      }
      public SalesOrder()
      {
          orderNumber = "";
          items = new ObservableCollection<Item>();
          Items.CollectionChanged += (s, args) =>
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
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).tbx_totalSale.Text =           CalculateTotalPrice().ToString();
                }
            }
            
        }
