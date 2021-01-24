    public ObservableCollection<BorgRealestate> Panden
    		{
    			get
    			{
    				if(ocPanden != null)
    				{
    					CollectionViewSource.GetDefaultView(ocPanden).Refresh(); //This will do the trick
    				}
    				return ocPanden ?? (ocPanden = new ObservableCollection<BorgRealestate>());
    			}
    			set
    			{
    				if (ocPanden == value)
    					return;
    
    				ocPanden = value;
    				OnPropertyChanged("Panden");
    			}
    		}
