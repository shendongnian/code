	class WorkerInt : IWorker<int>
	{
	    public void Do(IOpen<int> item)
	    {
	        Console.WriteLine(item.A);
	        //Console.WriteLine(item.B);
	    }
	}
