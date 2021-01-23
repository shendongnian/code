	public static void Main()
	{
	  string[] array = new string[] {"AAA","BBB","CCC","DDD","EEE","FFF","GGG","HHH"};
      List<string> list = new List<string>(array);
      list.RemoveRange(0,list.IndexOf("DDD")+1);
	  
	  foreach (string str in list)
	   {
	    Console.WriteLine(str);
       }
	}
