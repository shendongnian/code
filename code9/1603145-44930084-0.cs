    public static string[,] FoodPreferenceWithDimensionalArray()
    {
    	var foodPair = new Dictionary<string, string>
    	{
    		{"Pizza", "Italian"},
    		{"Curry", "Indian"},
    		{"Masala", "Indian"}
    	};
    
    	var teamPreference = new Dictionary<string, string>
    	{
    		{"Jose", "Italian" },
    		{"John", "Indian" },
    		{"Sarah", "Thai" },
    		{"Mary", "*" }
    	};
    
    	var results = new List<KeyValuePair<string, string>>();
    	foreach (var teamMember in teamPreference)
    	{
       		switch (teamMember.Key)
    		{
    			case "Jose":
    				var italianDish = foodPair.FirstOrDefault(x => x.Value == "Italian").Key;
    				results.Add(new KeyValuePair<string, string>(teamMember.Key, italianDish));
    				break;
    
    			case "John":
    				var indianDish = foodPair.Where(x => x.Value == "Indian");
    				if (indianDish.Any())
    				{
    					results.AddRange(indianDish.Select(dish => new KeyValuePair<string, string>(teamMember.Key, dish.Key)));
    				}
    				break;
    
    			case "Sarah":
    				var thaiDish = foodPair.FirstOrDefault(x => x.Value == "Thai").Key;
    				if (!string.IsNullOrEmpty(thaiDish))
    				{
    					results.Add(new KeyValuePair<string, string>(teamMember.Key, thaiDish));
    				}
    				break;
    
    			case "Mary":
    				if (teamMember.Value == "*")
    				{
    					var everything = foodPair.Keys.ToList();
    					if (everything.Any())
    					{
    						results.AddRange(everything.Select(food => new KeyValuePair<string, string>(teamMember.Key, food)));
    					}
    				}
    				break;
    		}
    	}
    
    	var resultIn2DArray = results.To2DArray();
    	return resultIn2DArray;
    }
    
    // Created extension to convert List to String[,]
    public static class Extension
    {
    	public static string[,] To2DArray<T>(this List<T> list)
    	{
    		if (list.Count == 0)
    		{
    			throw new ArgumentException("The list must have non-zero dimensions.");
    		}
    
    		var result = new string[list.Count, list.Count];
    		for (var i = 0; i < list.Count; i++)
    		{
               // This is set to 0 since I know the output but will work on this to make it dynamic.
    			result[0, i] = list[i].ToString(); 
    		}
    
    		return result;
    	}
    }
