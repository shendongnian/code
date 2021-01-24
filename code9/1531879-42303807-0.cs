    class Program
    {
    	static ConcurrentQueue<string> dirQueue = new ConcurrentQueue<string>();
    
    	static void Main(string[] args)
    	{
    		dirQueue.Enqueue(@"\\SomePC\SomeFolder");
    		fetch();
    		Console.ReadLine();
    	}
    
    	static void fetch()
    	{
    		string currentDirectory;
    
    		do
    		{
    			if (dirQueue.TryDequeue(out currentDirectory))
    			{
    				try
    				{
    					IEnumerable<string> newDirectories = Directory.EnumerateDirectories(currentDirectory, "*.*", SearchOption.TopDirectoryOnly);
    					Array.ForEach(newDirectories.ToArray(), dirQueue.Enqueue);
    
    					Console.WriteLine("{1}", currentDirectory);
    				}
    				catch (UnauthorizedAccessException ex)
    				{
    					Debug.WriteLine(ex.Message);
    				}
    			}
    		} while (!dirQueue.IsEmpty);
    	}
    }
