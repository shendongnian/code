    public class MyViewModel
    {
        [...]
        public ObservableCollection<MyModelVm> models = new ObservableCollection<MyModelVm>();
    }
    public class MyModel
    {
    	private string _data;
    	public string Data
    	{
    		get { return _data; }
    		set { _data = value; }
    	}
    }
