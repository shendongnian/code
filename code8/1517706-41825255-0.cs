    static void Main(string[] args)
    {         
    
    	string response = "";
        //define your list here.
    	List<int> toSort = new List<int>();
    
    	//Main Console Menu
    	while (response != "exit") 
    	{
    		Console.WriteLine("Type help for list of commands");
    		response = Console.ReadLine();
    
    		if (response.StartsWith("exit"))
    		{
    			Environment.Exit(0);
    		}
    
    		else if (response.ToLower().StartsWith("help"))
    		{
    			Help(response);
    		}
    
    		else if (response.ToLower().StartsWith("generate"))
    		{
    			toSort = Shuffle(Generate(response));
    		}
    
    		else if (response.ToLower().StartsWith("bubble"))
    		{
    			
    			List<int> sortedList = BubbleSort(toSort); 
    		}                           
    
    	}
    }
