	Action x = async () =>
	{
		try
		{
			Console.WriteLine("Hello");
			await Task.Delay(TimeSpan.FromSeconds(2.0));
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
