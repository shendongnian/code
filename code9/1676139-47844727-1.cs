    public class Property
    {
    	public string Name { get; set; }
    }
    
    var list1 = new List<Property>
    {
    	new Property { Name ="A" },
    	new Property { Name ="A" },
    	new Property { Name ="A" },
    	new Property { Name ="B" }
    };
    
    var list2 = new List<Property>
    {
    	new Property { Name ="A" },
    	new Property { Name ="B" },
    	new Property { Name ="B" }
    };
    
    var r = new List<string>();
    int x1 = 0, x2 = 0;
    int count1 = list1.Count, count2 = list2.Count;
    
    while (true)
    {
    	if (x1 == count1 && x2 == count2) break;
    
    	if (x1 < count1 && x2 == count2)
    	{
    		++x1; r.Add($"{list1[x1].Name}\tNULL");
    	}
    	else if (x1 == count1 && x2 < count2)
    	{
    		++x2; r.Add($"NULL\t{list2[x2].Name}");
    	}
    	else
    	{
    		if (list1[x1].Name == list2[x2].Name)
    		{
    			++x1; ++x2; r.Add($"{list1[x1].Name}\t{list2[x2].Name}");
    		}
    		else
    		{
    			++x1; r.Add($"{list1[x1].Name}\tNULL");
    		}
    	}
    }
