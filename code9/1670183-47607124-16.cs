    public class MyViewModel: INotifyPropertyChanged
    {
        //INotifyPropertyChanged implementation
    
    	public ObservableCollection<MyData> MyData 
    	{
    		get { return _myData }
    		set
    		{
    		     _myData = value;
    			 OnPropertiChange(nameof(MyData));
    		}
    	}
    
    	public virtual ICommand SearchCommand => new RelayCommand(o=> Search());
    
    	private void Search()
    	{
    		//DoSamething
    		
    		MyData = new ObservableCollection<MyData>(ListOfMyData);
    	}
    	
    }
