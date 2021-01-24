    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		var dishes = new List<Dish>{
    			new Dish{Id = 35, Name = "Pizza Funghi", Price = 11},
    			new Dish{Id = 01, Name = "Pasta Bolognese", Price = 10},
    			new Dish{Id = 02, Name = "Pasta Napolitana", Price = 9.5M},
    			new Dish{Id = 36, Name = "Pizza Carbonara", Price = 8}
    		};
    		var dishesDict = dishes.ToDictionary(d => d.Id);
    		
    		var selectedDishes = new List<Dish>();
    		Console.Write("Type in the number of the dish you want: ");
    		int id = Convert.ToInt32(Console.ReadLine());
    		
    		if (dishesDict.ContainsKey(id)) {
    		    var dish  = dishesDict[id];
    			selectedDishes.Add(dish);
    			Console.WriteLine(dish.Name + " is added to your list.");
    		}
    		else
    		{
    			Console.WriteLine( id + " is not available.");
    		}
    		
            // Example how to use additional property
    		var totalPrice = selectedDishes.Sum(d => d.Price);
    		Console.WriteLine("Total Price of selected dishes: " + totalPrice);
    	}
    }
    
    public class Dish {
    	
    	public int Id { get; set; }
    	public string Name { get; set; }
    	// Example of additional property
    	public decimal Price {get; set;}
    }
