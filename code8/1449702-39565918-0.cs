	static void Main(string[] args)
	{
		var rootPath = @"C:\Users\Mani\Documents";
	
		using (Observable
			.Interval(TimeSpan.FromSeconds(1.0))
			.Subscribe(x => Console.WriteLine($"Running{"".PadLeft((int)x % 3)}.")))
		{
			Thread2.processDirectory(rootPath);
		}
	
	}
	
	public static class Thread2
	{
		public static List<string> unauthorized = new List<string>();
		public static List<string> emptyFolders = null;
		public static void processDirectory(string rootPath)
		{
			if (!Directory.Exists(rootPath)) return;
	
			emptyFolders = 
				EnumerableEx
					.Expand(Directory.GetDirectories(rootPath), dir => Directory.GetDirectories(dir))
					.Where(dir => Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0)
					.ToList();
			
			emptyFolders
				.AsEnumerable()
				.Reverse()
				.ForEach(dir =>
				{
					try
					{
						Directory.Delete(dir, false);
					}
					catch (UnauthorizedAccessException uae) { unauthorized.Add(uae.Message); }
				});
		}
	}
