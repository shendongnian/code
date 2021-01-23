    private void GetData()
	{
		AppDelegate.FlagForGetData = true;
		Console.WriteLine("Began getting data.");
		System.Threading.Thread.Sleep(5000);
		AppDelegate.FlagForGetData = false;
		Console.WriteLine("Getting data succeed.");
	}
	private void GetMoreData()
	{
		Console.WriteLine("Began getting more data.");
		System.Threading.Thread.Sleep(3000);
		Console.WriteLine("Getting more data succeed.");
	}
