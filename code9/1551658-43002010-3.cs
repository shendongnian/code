    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    
    	public int SelectedTab
    	{
    		get { return _selectedTab; }
    		set
    		{
    			SetProperty(ref _selectedTab, value);
    			OnPropertyChanged("SelectedTab");
    		}
    	}
    }
