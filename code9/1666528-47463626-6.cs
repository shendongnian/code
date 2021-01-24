    private Product _productListSelectedItem;
	public Product ProductListSelectedItem
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
	
