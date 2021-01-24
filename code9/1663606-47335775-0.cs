    public static async Task DelayAndReturn(int number, int milisecDelay)
    {
        await Task.Delay(milisecDelay);
	    Console.WriteLine(number);
    }
    public static void Main(string[] args)
    {
        PrintReversed().GetAwaiter().GetResult();
    }
	
	public static async Task PrintReversed() {
		int[] arr = { 1, 2, 3 };
        int milisecDelay = 1000;
	
	    List<Task> tasks = new List<Task>();
        foreach (int num in arr)
        {
           tasks.Add(DelayAndReturn(num, milisecDelay));
           milisecDelay /= 10;
        }
	
	    await Task.WhenAll(tasks);
	}
