    using System;
    using System.Threading.Tasks;
    
    namespace Brad
    {
    	public class Program
    	{
    		public static void Main(string[] args)
    		{
    			var task = new Program().Start();
    			Console.WriteLine("Wait...");
    			// You have to put a synchronous Wait() here because
    			// Main cannot be declared as async
    			task.Wait();
    		}
    
    		public async Task Start()
    		{
    			int num1 = await GetNumber();
    			int num2 = await GetNumber();
    			int num3 = await GetNumber();
    			Console.WriteLine("Finished");
    		}
    
    		public static async Task<int> GetNumber()
    		{
    			await Task.Delay(TimeSpan.FromMilliseconds(400));
    			Console.WriteLine("Hello");
    			return 0;
    		}
    	}
    }
