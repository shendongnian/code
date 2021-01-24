    private int _productListSelectedIndex;
	public int ProductListSelectedIndex
	{
		get { return _productListSelectedIndex; }
		set
		{
			if (_productListSelectedIndex != value)
			{
				_productListSelectedIndex = value;
				NotifyPropertyChanged();
			}
		}
	}
	
