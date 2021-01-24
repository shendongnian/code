    public class MainViewModel: INotifyPropertyChanged
    {
        Random _rnd = new Random();
    	private MyGridData _selectedData;
    	private ObservableCollection<MyGridData> _gridData;
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    
    	public MainViewModel()
    	{
    		var newData = new List<MyGridData>
    		{
    			new MyGridData { Column1 = "AAAAAA 01", Column2 = "aaaaaaaa 02" },
    			new MyGridData { Column1 = "BBBBBB 01", Column2 = "bbbbbbbb 02" },
    			new MyGridData { Column1 = "CCCCCC 01", Column2 = "cccccccc 02" },
    		};
    		GridData = new ObservableCollection<MyGridData>(newData);
    	}
    
    	public MyGridData SelectedData
    	{
    		get { return _selectedData; }
    		set
    		{
    			if (value == _selectedData) //if same item selected
    				return;
    			_selectedData = value;
    			OnPropertyChanged();
    
    			DoSomethingWhenValueChanged(); // Will add a new line
    		}
    	}
    	public ObservableCollection<MyGridData> GridData
    	{
    		get { return _gridData; }
    		set
    		{
    			if (value == _gridData)
    				return;
    			_gridData = value;
    			OnPropertyChanged();
    		}
    	}
    
    	private void DoSomethingWhenValueChanged()
    	{
    		var newData = GridData.ToList();
    		newData.Add(new MyGridData { Column1 = (_rnd.Next(100)).ToString(), Column2 = (_rnd.Next(1000)).ToString() }); //Add new random item
    
    		GridData = new ObservableCollection<MyGridData>(newData);  //update your DataGrid
    	}
    }
    public class MyGridData
    {
    	public string Column1 { get; set; }
    	public string Column2 { get; set; }
    }
