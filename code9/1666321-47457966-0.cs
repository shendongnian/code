	public async Task Work(ConcurrentQueue<string> input, ConcurrentQueue<bool> output)
	{
		string current;
		while (input.TryDequeue(out current))
		{
			output.Enqueue(await DownloadThenWriteThenReturnResult(current));
		}
	}
	var nbThread = 4;
	var input = new ConcurrentQueue<string>(_myStrings);
	var output = new ConcurrentQueue<bool>();
	var workers = new List<Task>(nbThread);
	for (int i = 0; i < nbThread; i++)
	{
		workers.Add(Task.Run(async () => await this.Work(input, output)));
	}
	await Task.WhenAll(workers);
