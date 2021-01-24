    public static List<Tuple<Person, DateTime?>> GetMax(List<Person> personList)
    {
    	List<Tuple<Person, DateTime?>> list = new List<Tuple<Person, DateTime?>>();
    
    	foreach (Person p in personList)
    	{
    		DateTime? maxDate = null;
    
    		var properties = p.GetType().GetProperties();
    		foreach (var property in properties)
    		{
    			if (property.PropertyType == typeof(DateTime?))
    			{
    				DateTime? date = (DateTime?)property.GetValue(p);
    				maxDate = Max(maxDate, date);
    			}
    		}
    
    		list.Add(new Tuple<Person, DateTime?>(p, maxDate));
    	}
    
    	return list;
    }
    
    static DateTime? Max(DateTime? a, DateTime? b)
    {
    	if (!a.HasValue && !b.HasValue) return a;  // doesn't matter
    
    	if (!a.HasValue) return b;
    	if (!b.HasValue) return a;
    
    	return a.Value > b.Value ? a : b;
    }
