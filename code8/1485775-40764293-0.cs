    protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
   	{
   		base.OnItemsSourceChanged(oldValue, newValue);
   		if (AutoGenerateColumns && newValue != null && newValue.GetType().IsGenericType)
   		{
   			this.Columns.Clear();
    
   			var type = newValue.GetType().GetGenericArguments().First();
    
   			if (typeof(IMyColumnDescriptionStructure).IsAssignableFrom(type))
   			{
   				var rows = newValue as IEnumerable<IMyColumnDescriptionStructure>;
   				var firstRow = rows.First() as IMyColumnDescriptionStructure;
    
   				// TODO: explore your structure and add column definitions
       			///this.Columns.Add(...)
    		}
    	}
    }
