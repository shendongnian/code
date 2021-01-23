    int n = int.Parse(Console.ReadLine());
    Dictionary<string,string> phoneBook = new Dictionary<string,string>();
    
    for (int i = 0; i < n; i++)
    {
    	var names = Console.ReadLine().Split(' ');
    	phoneBook.Add(names[0], names[1] );
    }
    
    string name = Console.ReadLine();
    do
    { 
    	string printValue = "Not found";
    	if (phoneBook.ContainsKey(name))
    	{
    		printValue = name + "=" + phoneBook[name];
    	}
    	
    	Console.WriteLine(printValue);
    
    	name = Console.ReadLine();
    
    }while(!string.IsNullOrEmpty(name)); 
