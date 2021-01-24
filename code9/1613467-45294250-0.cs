	Action x = async () =>
	{
		Console.WriteLine("Hello");
		await Task.Delay(TimeSpan.FromSeconds(2.0));
		try
		{
			throw new Exception("Wait");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		Console.WriteLine("Goodbye");
	};
	var d = Disposable.Create(x);
	d.Dispose();
