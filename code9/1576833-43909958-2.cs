    List<string> dbCategories_Names = dbCategories.Select(x => x.Name).ToList();
    
    for (int i = newCategories.Count-1; i >= 0 ; i--)
    {
    	if (dbCategories_Names.Contains(newCategories[i].Name))
    	{
    		newCategories.RemoveAt(i);
    	}
    }
