    class theClass
    {
        string name;
        string dob;
        int age;
    
        public theClass(string name, int age, string dob)
        {
            this.name = name;
            this.age = age;
            this.dob = dob;
        }
    	
    	public string CanVote => age >= 18 ? "Can Vote" : "Cannot Vote";  
    }
    public static void Main()
    {
    	    Hashtable h = new Hashtable();
            theClass object1 = new theClass("John",16,"Chennai");
            theClass object2 = new theClass("Smita",22, "Delhi");
            theClass object3 = new theClass("Vincent",25, "Banglore");
            theClass object4 = new theClass("Jothi", 10, "Banglore");
    
            h.Add("John", object1);
            h.Add("Smita", object2);
            h.Add("Vincent", object3);
            h.Add("Jothi", object4);
    		
    		foreach(DictionaryEntry item in h){
    			Console.WriteLine(item.Key);
    			Console.WriteLine((item.Value as theClass).CanVote);
    			Console.WriteLine();
    		}
            
            Console.ReadKey();
    }
