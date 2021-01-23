    public static void getList()
    {
    	var list1 = new[] {
    						new {Section = "section2", BeginningValue = 31507976.71, EndingValue=0},
    						new {Section = "section6", BeginningValue = 31643256.16, EndingValue=0},
    						new {Section = "section8", BeginningValue = 32297021.88, EndingValue=0},
    						new {Section = "section14", BeginningValue = 31643256.16, EndingValue=0},
    					};
    	var list2 = new[]{
    						new {Section = "section2",  EndingValue=31406327.47},
    						new {Section = "section8",  EndingValue=33863875.36},
    						new {Section = "section10", EndingValue=32674862.89},
    					};
    
    	var result = from Item1 in list1
    				 join Item2 in list2
    				 on Item1.Section equals Item2.Section into ps
    				 from p in ps.DefaultIfEmpty()
    				 select new
    				 {
    					 Section = Item1.Section,
    					 BeginningValue = Item1.BeginningValue,
    					 EndingValue = (p != null ? p.EndingValue : Item1.EndingValue)
    				 };
    
    	foreach (var item in result)
    		Console.WriteLine(item.Section + "-" + item.BeginningValue + "-" + item.EndingValue);
    }
