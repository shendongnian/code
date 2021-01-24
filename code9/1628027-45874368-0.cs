    public Product SelectedProduct
    {
      set 
        {
           // your private member setting...
           // raise property change for crystal collection for UI to respond
        }
    }
    public Product SelectedCrystal
    {
      set 
      {
         // your private member setting...
         // raise property change for crystal collection for UI to respond
      }
    }
    public ObservableCollection<Crystal> Crystals
    {
      get 
        {
           if (SelectedProduct != null)
             return SelectedProduct.Crystals;
           
           return new ObservableCollection<Crystal>();
        }
    }
