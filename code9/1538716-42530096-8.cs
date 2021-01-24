    	bool rollingBack = false;
    	private void RollBack(NotifyCollectionChangedEventArgs args) {
    		    rollingBack = true;
    			if (args.Action == NotifyCollectionChangedAction.Remove)
    			{
    				foreach (var element in args.OldItems) {
    					PosInLocationsList.Add((PosInLocation)element);
    				}
    			}
    			if (args.Action == NotifyCollectionChangedAction.Add)
    			{
    				foreach (var element in args.NewItems) {
    					PosInLocationsList.Remove((PosInLocation)element);
    				}
    			}
    			rollingBack = false;
    	}
