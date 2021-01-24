    public class Model : INotifyPropertyChanged
    {
    	public Model(string val)
    	{
    		Value = val;
    	}
    
    	string Value { get; set; }
    
    	public event PropertyChangedEventHandler PropertyChanged;
    }
    static void Main(string[] args)
    {
    	ObservableCollection<Model> collection = new ObservableCollection<Model>();
    	collection.Add(new Model("item1"));
    	collection.Add(new Model("item2"));
    	collection.Add(new Model("item3"));
    	collection.CollectionChanged += (sender, e) =>
    	{
    		if (e.Action == NotifyCollectionChangedAction.Remove)
    		{
    			var removedItems = e.OldItems; // put a breakpoint here to observe
    		}
    	};
    
    	collection.RemoveAt(1);
    
    	Console.ReadLine();
    }
