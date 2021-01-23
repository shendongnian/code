    public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
    	if (this.PropertyChanged != null)
    	{
    		this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
