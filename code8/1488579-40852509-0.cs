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
