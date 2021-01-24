    using System;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		enum fun
    		{
    			None,
    			UpArrow,
    			DownArrow,
    			LeftArrow,
    			RightArrow
    
    		}
    		static void Main(string[] args)
    		{
    			fun val = fun.None;
    
    			Console.WriteLine("Start using your arrow key on your keyboard!");
    
    			do
    			{
    				if (val != fun.None)
    				{
    					Console.WriteLine(val);
    				}
    			}
    			while (Enum.TryParse<fun>(Console.ReadKey().Key.ToString(), out val));
    
    			Console.WriteLine("Invalid key bye bye");
    
    			Console.ReadKey();
    		}
    	}
    }
