    //Row Style.
    gridview1.LoadingRow += (_sender, _e) =>
    	{
    		ProdutctModel item = (ProductModel)_e.Row.DataContext;
    		if (item != null)
    		{
    			if (item.ProductType.Equals("Buy"))
    				_e.Row.Foreground = new SolidColorBrush(Colors.Red);
    			else if (item.ProductType.Equals("Sale"))
    				_e.Row.Foreground = new SolidColorBrush(Colors.Green);
    		}
    	};
