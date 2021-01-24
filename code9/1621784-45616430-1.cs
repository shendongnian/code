    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
	    internal class Program
	    {
		    private static void Main(string[] args)
		    {
			    Parallel.Invoke(PrintLoop, async () => Console.WriteLine(await GetAnswerToLife()));
		    }
		    public static void PrintLoop()
		    {
			    for (int i = 0; i < 100; i++)
			    {
				    Console.WriteLine(i);
				    Thread.Sleep(100);
			    }
		    }
		    public static async Task<int> GetAnswerToLife()
		    {
			    await Task.Delay(5000);
			    return 21 * 10;
		    }
	    }
    }
