    public void Recursive(Dictionary<int, DataTable> insertTableOrder, ref int index, DataTable child1, DataSet ds)
    {
    	foreach (DataRelation rel in ds.Relations)
    		if (child1 == rel.ParentTable)
    		{
    			var child2 = rel.ChildTable;
    			var relName2 = rel.RelationName;
    
    			if (insertTableOrder.Where(w => w.Value.TableName == child2.TableName).Count() == 0)
    				insertTableOrder.Add(index++, child2);
    
    			Recursive(insertTableOrder, ref index, child2, ds);
    		}
    }
