    protected virtual void OnPropertyChanged(params string[] propNames)
    {
    		if (propNames!=null && PropertyChanged!=null)
    		{
    			foreach (var propName in propNames)
    			{
    				PropertyChanged(this, new PropertyChangedEventArgs(propName));
    			}
    		}
    }
    
    public object this[string key]
    {
        get
        {
    
            return this.SourceData[key];
    
        }
        set
        {
    
            OnPropertyChanging(Binding.IndexerName);
    
            this.SourceData[key] = value;
    
            OnPropertyChanged(Binding.IndexerName, key);
    
        }
    }
