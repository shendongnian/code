    public int Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
				_height = YOUR CALCULATED VALUE
                 **All other bits you want to do here**
				OnPropertyChanged("Width");
				OnPropertyChanged("Height");
			}
		}
