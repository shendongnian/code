    public YourPage
    {
      BindingContext = this;
    }    
     ....
    private List<Data> _items; 
    public List<Data> Items
    {
       get { return _items;} 
       set 
         {
            _items = value;
            OnPropertyChanged();
         }
    }
