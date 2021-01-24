    private Color _backgrcolor;
    	public Color BacrGrColor
    	{
    		get { return _backgrcolor; }
    		set
    		{
    			if (_backgrcolor.Equals(value))
    				return;
    			_backgrcolor = value;
    			OnPropertyChanged("BacrGrColor");
    		}
    	}
