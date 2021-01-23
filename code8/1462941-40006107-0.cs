    using System;
    					
    public class Program
    {
    	public static void Main(string[] args)
        {
            Action action = () => Console.WriteLine("Foo");
            // This is a stand-in for the event.
            Action x = null;
            x += action;
            x += action;
            x += action;
            x -= action;
            x(); // Prints Foo twice
        }
    }
