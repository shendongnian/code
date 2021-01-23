    void Main()
    {
    	List<classname> mylist=new List<classname>()
    	{
    		new classname { test = "test1", name = "name1", value = "value1" },
    		new classname { test = "test1", name = "name2", value = "value2" },
    		new classname { test = "test2", name = "name1", value = "value1" },
    		new classname { test = "test2", name = "name1", value = "value3" },
    		new classname { test = "test2", name = "name3", value = "value3" },
    		new classname { test = "test3", name = "name4", value = "value4" }
    	};
    	
    	var groups = mylist.GroupBy(x => x.name);
    	foreach(var group in groups)
    	{
    	    // name property value
    	    //Console.WriteLine(group.Key);
    	    foreach(var row in group)
    	    {
    	        // unique rows for this "name" group
    	        Console.WriteLine($"{row.test} {group.Key} {row.value}");
    	    }
    		Console.WriteLine();
    	}
    }
    
    public class classname
    {
        public String test { set; get; }
        public String name { set; get; }
        public String value{ set; get; }
    }
