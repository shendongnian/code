    public List<Plate> MyPlates
    {
    	get
    	{
    		return ((App)Application.Current).MyGlobalListofPlates;
    	}
    	set
    	{
    		((App)Application.Current).MyGlobalListofPlates = value;
    		OnPropertyChanged("MyPlates");
    	}
    }
