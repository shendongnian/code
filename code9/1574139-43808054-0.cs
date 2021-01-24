	void Main()
	{
		var filename = @"C:\Documents\SampleText.txt";
		var stocks = new List<Record>();	
		using (TextReader reader = File.OpenText(filename))
		{
			while (reader.Peek() > -1)
			{			
				var values = reader.ReadLine().Split(',');
				stocks.Add(new Record
				{
					GTIN = values[0],
					GTIN_INFO = values[1],
					WHATEVER = values[2],
					PRICE = values[3]
				});
			}
		}
		stocks.Dump();
	}
	// Define other methods and classes here
	class Record
	{
		public string GTIN { get; set; }
		public string GTIN_INFO { get; set; }
		public string WHATEVER { get; set; }
		public string PRICE { get; set; }
	}
