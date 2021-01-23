    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		private static int AA(string a) { return 0; }
    		private static int BB(string a) { return 1; }
    		private static int CC(string a) { return 2; }
    
    		private static Func<string, int>[] functions = new Func<string, int>[] { AA, BB, CC };
    		private static int[] prices = new int[functions.Length];
    		private static Task[] tasks = new Task[functions.Length];
    
    		static void Main(string[] args)
    		{
    			for (int i = 0; i < functions.Length; ++i)
    				tasks[i] = Task.Run(() => { prices[i] = functions[i]("a string"); });
    			Task.WaitAll(tasks);
    		}
    	}
    }
