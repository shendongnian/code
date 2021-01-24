    public abstract class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
	    protected virtual void OnPropertyChanged(string propertyName)
	    {
		    OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
	    }
	    protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
	    {
		    var handler = PropertyChanged;
		    handler?.Invoke(this, args);
	    }
    }
    
    public class YourViewModel : ViewModelBase {
    
	    private ObservableCollection<MyData> _searchCollection ;
	    public ObservableCollection<MyData> SearchCollection 
	    {
		    get { return _searchCollection; }
		    set { _searchCollection = value; OnPropertyChanged("SearchCollection"); }
	    }
	
    }
