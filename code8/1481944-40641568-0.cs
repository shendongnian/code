	class MainClass
	{
		public static void Main(string[] args)
		{
			Task.Run(() =>
			{
				Repository.Clone("https://github.com/sushihangover/SVGKit.Binding", Path.Combine(Path.GetTempPath(), "foobar"),
					new CloneOptions { OnTransferProgress = MainClass.TransferProgress });
			}).Wait();
		}
		public static bool TransferProgress(TransferProgress progress)
		{
			Console.WriteLine($"Objects: {progress.ReceivedObjects} of {progress.TotalObjects}, Bytes: {progress.ReceivedBytes}");
			return true;
		}
	}
