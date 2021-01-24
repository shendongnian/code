    public abstract class ViewModelBase : INotifyPropertyChanged
    {
	    public virtual ICommand MyCommand => new RelayCommand(MyClick);
	    protected virtual void MyClick(object o)
	    {
		    //Nothing here, just exists to be overriden
	    }
	}
