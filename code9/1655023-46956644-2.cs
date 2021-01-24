    public class MyViewModel : BaseViewModel //whatever base class you use to notify of property changes.
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
