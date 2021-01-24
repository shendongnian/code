    public class Account
    {
        public int Id { get; set; }
        public Category Category { get; set; }
    }
    public class Category
    {
    	public int Id { get; set; }
    	
    	public List<Photo> Photos { get; set; }
    }
    public class Photo
    {
    	public string Absolute { get; set; }
    
    	public string Relative { get; set; }
    }
    private static void Main(string[] args)
    {
    	var dictionary = new Dictionary<string, object>();
    	dictionary.Add("id", 1);
    	dictionary.Add("category[id]", 1);
    
    	dictionary.Add("category[photos][0][absolute]", "Absolute");
    	dictionary.Add("category[photos][0][relative]", "Relative");
    	dictionary.Add("category[photos][1][absolute]", "Absolute");
    	dictionary.Add("category[photos][1][relative]", "This is relative");
    
    	var instance = Activator.CreateInstance(typeof(Account));
    
    	foreach (var key in dictionary.Keys)
    	{
    		var parameters = key.Replace("[", ",").Replace("]", ",").Split(',').Where(x => !string.IsNullOrEmpty(x)).ToList();
    		Read(instance, parameters, dictionary[key]);
    	}
    
    	var a = 1;
    }
    private static void Read(object model, IList<string> parameters, object value)
    {
    	// Initiate model pointer.
    	var pointer = model;
    
    	// Find the last key.
    	var lastKey = parameters[parameters.Count - 1];
    
    	// Initiate property information.
    	PropertyInfo propertyInfo = null;
    
    	// Loop through every keys.
    	for (var index = 0; index < parameters.Count - 1; index++)
    	{
    		// Find key.
    		var key = parameters[index];
    
    		// Whether key is numeric or not.
    		// Collection should be used numeric index to insert to list.
    		if (IsNumeric(key))
    		{
    			int iCollectionIndex;
    			if (!int.TryParse(key, out iCollectionIndex))
    				break;
    
    			if (propertyInfo == null)
    				break;
    
    
    			var itemCount = (int)propertyInfo.PropertyType.GetProperty("Count").GetValue(pointer, null);
    			var genericArguments = propertyInfo.PropertyType.GetGenericArguments();
    
    			//var iGenericListArgumentTotal = propertyInfo.PropertyType.GetMethod("Count").Invoke(pointer, new[] { null });
    			if (iCollectionIndex > itemCount - 1)
    			{
    				var listItem = Activator.CreateInstance(propertyInfo.PropertyType.GetGenericArguments()[0]);
    				propertyInfo.PropertyType.GetMethod("Add").Invoke(pointer, new[] { listItem });
    				pointer = listItem;
    				continue;
    			}
    
    			var commandSelectItem = typeof(Enumerable)
    				.GetMethod("ElementAt")
    				.MakeGenericMethod(genericArguments[0]);
    
    			// Find item at specific index.
    			pointer = commandSelectItem.Invoke(pointer, new[] { pointer, iCollectionIndex });
    		}
    
    		// Find property information of pointer.
    		propertyInfo = FindInstanceProperty(pointer, key);
    
    		// Property hasn't been initialized.
    		if (propertyInfo == null)
    			break;
    
    		var val = propertyInfo.GetValue(pointer);
    		if (val == null)
    		{
    			val = Convert.ChangeType(Activator.CreateInstance(propertyInfo.PropertyType),
    				propertyInfo.PropertyType);
    			propertyInfo.SetValue(pointer, val);
    			pointer = val;
    			continue;
    		}
    
    		pointer = val;
    	}
    
    	// Find last property.
    	propertyInfo = FindInstanceProperty(pointer, lastKey);
    
    	if (propertyInfo != null)
    		propertyInfo.SetValue(pointer, Convert.ChangeType(value, propertyInfo.PropertyType));
    }
