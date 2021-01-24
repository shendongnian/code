    Dictionary<int, DataTable> insertTableOrder = new Dictionary<int, DataTable>();
    foreach (var parent in topParents)
    {
    	foreach (DataRelation rel1 in ds.Relations)
    	{
    		if (rel1.ParentTable == parent)
    		{
    			var child1 = rel1.ChildTable;
    			var relName1 = rel1.RelationName;
    
    			if (insertTableOrder.Where(w => w.Value.TableName == parent.TableName).Count() == 0)
    				insertTableOrder.Add(index++, parent);
    
    			if (insertTableOrder.Where(w => w.Value.TableName == child1.TableName).Count() == 0)
    				insertTableOrder.Add(index++, child1);
    
    			Recursive(insertTableOrder, ref index, child1, ds);
    		}
    	}
    }
