	class WorkerInt : IWorker<int>
	{
	    public void Do(Concrete item)
	    {
	        Console.WriteLine(item.A);
	        Console.WriteLine(item.B);
	    }
	}
