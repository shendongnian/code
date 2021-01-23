    public int CurrentCategory
    {       
      get { return _currentCategory; }
      set
      {
          _currentCategory = value;
          ProductsInCategory = DBAccess.GetProductsInCategory(_currentCategory).Tables["Products"].DefaultView;
          OnPropertyChanged("CurrentCategory");
      } 
    }
