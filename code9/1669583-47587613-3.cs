    public static void Main()
    {
            Dictionary<string, theClass> dict = new Dictionary<string, theClass>{
    		   {"John", new theClass("John", 16, "Chennai")},
    		   {"Smita", new theClass("Smita", 22, "Delhi")},
    		   {"Vincent", new theClass("Vincent",25, "Banglore")},
    		   {"Jothi", new theClass("Jothi", 10, "Banglore")}
    		};
    		
    		foreach(var item in dict){
    			Console.WriteLine(item.Key);
    			Console.WriteLine(item.Value.CanVote);
    			Console.WriteLine();
    		}
    		
            Console.ReadKey();
    }
