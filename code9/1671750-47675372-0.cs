    public abstract class ViewModelBase : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    
    
    	public virtual ICommand NavigateCommand => new RelayCommand(Navigate);
    
    	protected virtual void Navigate(object param)
    	{
    
    	}
    
    }
