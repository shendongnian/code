    using System;
    using System.Collections.Generic;
					
    public class Program
    {
	    private static List<Dog> dogs;
    	
    	public static void Main(string[] args)
    	{
    		//calling working print feature from within the list function
    		DogDatabase.dogList();
    		DogDatabase.print();
    		Console.ReadLine();
    	}
    	
    	public class DogDatabase
    	{
    		public static void dogList()
    		{
    			//lists the Dog class from above
    			dogs = new List<Dog>();
    			dogs.Add(new Dog("Baxter", "blue", "me"));
    			dogs.Add(new Dog("Fido", "Black", "peter"));
    		}
    		public static void print()
    		{                
    			//the foreach loops for printing the list
    			foreach (Dog printDog in dogs)
    			{
    				Console.WriteLine(printDog.name + " " + printDog.colour);
    			}
    		}
    	 }
    	
    	public class Dog
    	{
    		//class that is being added to the list
    		public string owner;
    		public string name;
    		public string colour;
    		public Dog()
    		{
    			owner = "unkown";
    			name = "unknown";
    			colour = "unknown";
    		}
    	
    		public Dog(string nm, string cl, string ow)
    		{
    			name = nm;
    			colour = cl;
    			owner = ow;
    		}
    	
    		public string talk()
    		{
    			return "woof woof";
    		}
    	
    		public string eat(string food)
    		{
    			return name + "eats" + food;
    		}
    	
    		public void SetName(string newName)
    		{
    			name = newName;
    		}
    	
    		public void SetColour(string newColour)
    		{
    			colour = newColour;
    		}
	    }	
    }
