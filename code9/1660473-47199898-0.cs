    public static void Main()
	{
		List<string> list =  new List<string>();
		list.Add("item1");
		list.Add("item2");
		list.Add("item3");
		list.Add("item4");
		getList(list);
	}
	
	static void getList(List<string> list)
	{
	  foreach(string s in list)
	  {
	    Console.WriteLine(s);
	  }
	
	}
