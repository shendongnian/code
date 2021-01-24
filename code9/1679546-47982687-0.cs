    public class ViewModelBase:INotifyPropertyChanged{
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    	protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
    	{
    		PropertyChanged?.Invoke(this, args);
    	}
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
    	{
    		//TODO: when we remove the old OnPropertyChanged method we need to uncomment the below line
    		//OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    		OnPropertyChanged(propertyName);
    	}
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    	{
    		if (Equals(storage, value)) return false;
    
    		storage = value;
    		RaisePropertyChanged(propertyName);
    
    		return true;
    	}
    }
