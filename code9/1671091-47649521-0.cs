    using System.Collections.Generic;
    
    public class Program
    {
    	class Friend
    	{
    		public string Name {get;set;}    
    		public int Age {get;set;}
    
    		public Friend(string name, int age)
    		{
    			Name = name;
    			Age = age;
    		}
    	}
    
    	public static void Main()
    	{
    		// this is my class object
    		Friend f1 = new Friend("Nazir", 24);
    		Friend f2 = new Friend("Hamza", 24);
    		Friend f3 = new Friend("Abdullah", 23);
    		var myDict = new Dictionary<string, Friend>();
    		// add this object in hashtable object
    		myDict["13b-049-bs"] = f1;
    		myDict["13b-034-bs"] = f1;
    		myDict["13b-038-bs"] = f1;
    		foreach (KeyValuePair<string, Friend> item in myDict)
    		{
    			Console.WriteLine("Key {0}\tName {1}\tAge {2}", item.Key, item.Value.Name, item.Value.Age);
    		}
    	}
    }
