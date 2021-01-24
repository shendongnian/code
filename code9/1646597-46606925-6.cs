    public static class ObservableCollectionExtensions
    {
    	public static Hook<TList> RegisterPropertyChangeHook<TList>(this ObservableCollection<TList> collection, PropertyChangedEventHandler handler) where TList : INotifyPropertyChanged
    	{
    		void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    		{
    			switch (e.Action)
    			{
    				case NotifyCollectionChangedAction.Add:
    					foreach (TList item in e.NewItems)
    					{
    						item.PropertyChanged += handler;
    					}
    					break;
    				case NotifyCollectionChangedAction.Remove:
    					foreach (TList item in e.OldItems)
    					{
    						item.PropertyChanged -= handler;
    					}
    					break;
    				default:
    					break;
    			}
    		}
    
    		return new Hook<TList>(collection, Collection_CollectionChanged);
    	}
    
    	public class Hook<TList> where TList : INotifyPropertyChanged
    	{
    		internal Hook(ObservableCollection<TList> collection, NotifyCollectionChangedEventHandler handler)
    		{
    			_handler = handler;
    			_collection = collection;
    
    			collection.CollectionChanged += handler;
    		}
    
    		private NotifyCollectionChangedEventHandler _handler;
    		private ObservableCollection<TList> _collection;
    
    		public void Unregister()
    		{
    			_collection.CollectionChanged -= _handler;
    		}
    	}
    }
