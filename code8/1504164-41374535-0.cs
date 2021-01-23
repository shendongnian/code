	List<string> newcategories = new List<string>();
	foreach(var category in categories)
	{
		if(category.Contains(","))
		{
			string[] c = category.Split(',');
			newcategories.Add(c[0]);
			newcategories.Add(c[1]);
		}
		else
		{
			newcategories.Add(category);
		}
	}
