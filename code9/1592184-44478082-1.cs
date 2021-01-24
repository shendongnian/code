    public abstract class ViewModelBase : INotifyPropertyChanged
    {
    	protected void RaisePropertyChanged(string propertyName)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    }
    
    
    public class Item : ViewModelBase, INotifyPropertyChanged
    {
    	private string _approver;
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public string Approver
    	{
    		get { return _approver; }
    		set
    		{
    			if (_approver != value)
    			{
    				_approver = value;
    				RaisePropertyChanged(nameof(Approver));
    			}
    		}
    	}
    }
    
    public class MyViewModel : ViewModelBase
    {
    
    	public MyViewModel()
    	{
    		UpdateDataCommand = new RelayCommand(_ => UpdateAll());
    	}
    
    	public ObservableCollection<Item> AllItems { get; set; } = new ObservableCollection<Item>();
    
    	public ICommand UpdateDataCommand { get; set; }
    	private void UpdateAll()
    	{
    		//Fetch from DB
    		var items = new[]
    		{
    			new Item {Id=1, Name="Item 1", Approver="Lance"},
    			new Item {Id=2, Name="Item 2", Approver="John"}
    		};
    
    		AllItems.Clear();
    		foreach (var item in items)
    		{
    			AllItems.Add(item);
    		}
    	}
    }
