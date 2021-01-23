    private List<Dish> _subMenuItems = new List<Dish>();
    public IEnumerable<Dish> SubMenuItems { get { return _subMenuItems; } }
    public void AddDish(Dish dish)
    {
        _subMenuItems.Add(dish);
        dish.PropertyChanged += dish_PropertyChanged;
        OnPropertyChanged("SubMenuItems");
    }
    public void RemoveDish(Dish dish)
    {
        if (_subMenuItems.Contains(dish))
        {
            dish.PropertyChanged -= dish_PropertyChanged;
            _subMenuItems.Remove(dish);
            OnPropertyChanged("SubMenuItems");
        }
    }
    private double _total;
    public double Total
    {
        get { return _total; }
        set
        {
            if (_total != value)
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }
    }
    private void dish_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        Total = getTotal();
        // any other aggregate calculations can go here.
        OnPropertyChanged("SubMenuItems");
    }
