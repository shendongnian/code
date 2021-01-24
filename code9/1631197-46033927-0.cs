    public static ExpandoObject DicTobj(Dictionary<string, object> properties)
    		{
    			var eo = new ExpandoObject();
    			var eoColl = (ICollection<KeyValuePair<string, object>>)eo;
    
    			foreach (var childColumn in properties)
    				eoColl.Add(childColumn);
    
    			return eo;
    		}
