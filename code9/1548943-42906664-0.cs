    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
    	public static void Main()
    	{
    		List<IThing> testCollection = new List<IThing>();
    		testCollection.Add(new Ball());
    		testCollection.Add(new Car());
    		try
    		{
    		if (testCollection[0] is Ball)
    		{
    			Console.WriteLine(testCollection.Cast<Ball>().Count().ToString());
    		}
    		else
    		{
    			Console.WriteLine(testCollection.Cast<Car>().Count().ToString());
    		}
    		}
    		catch(InvalidCastException ex)
    		{
    			Console.WriteLine("Mix isn't allowed!");
    		}
    	}
    }
    
     public interface IThing
        {
            string Id { get; set;}
        }
        public class Ball : IThing
        {
            public string Id { get;set; }
        }
    
        public class Car : IThing
        {
            public string Id { get;set; }
        }
