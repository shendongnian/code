    int sum = 0;
	Task t1 = Task.Factory.StartNew(() =>
	{
		 Interlocked.Add(ref sum,Computation());
	});
	Task t2 = Task.Factory.StartNew(() =>
	{
		 Interlocked.Add(ref sum,Computation());
	});
	Task t3 = Task.Factory.StartNew(() =>
	{
		 Interlocked.Add(ref sum,Computation());
	});
	Task.WaitAll(t1, t2, t3);
	Console.WriteLine($"The sum is {sum}");
