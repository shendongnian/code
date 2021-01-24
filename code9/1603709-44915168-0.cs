    class Program
    {
        static void Main(string[] args)
        {
    		using (StreamReader reader = new StreamReader(args[0]))
    		{
    			while (true)
    			{
    				string line = reader.ReadLine();
    				if (line == null)
    				{
    					break;
    				}
    				Console.WriteLine(line); // Use line.
    			}
    		}
    	}
    }	
