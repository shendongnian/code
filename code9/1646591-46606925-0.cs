    public static class ObservableCollectionExtensions
    {
    	public static void RegisterPropertyChangeHook<TList>(this ObservableCollection<TList> collection, PropertyChangedEventHandler handler) where TList : INotifyPropertyChanged
    	{
    		collection.CollectionChanged += Collection_CollectionChanged;
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
    	}
    }
