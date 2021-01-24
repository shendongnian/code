    private int _productListSelectedItem;
	public int ProductListSelectedItem
	{
		get { return _productListSelectedItem; }
		set
		{
			if (_productListSelectedItem != value)
			{
				_productListSelectedItem = value;
				NotifyPropertyChanged();
			}
		}
	}
	
