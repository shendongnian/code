    public string Name
    {
    	get { return book.Name; }
    	set
    	{
    		book.Name = value;
    		this.NotifyPropertyChanged();
    	}
    }
