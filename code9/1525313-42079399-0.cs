    class LemonAtDate
	{
		public DateTime Date { get; set; }
		public double Value { get; set; }
		public LemonAtDate(DateTime Date, double Value)
		{
			this.Date = Date;
			this.Value = Value;
		}
		public static List<LemonAtDate> LoadFromFile(string filepath)
		{
			IEnumerable<String[]> lines = System.IO.File.ReadLines(filepath).Select(a => a.Split(','));
			List<LemonAtDate> result = new List<LemonAtDate>();
			int index = 0;
			foreach (String[] line in lines)
			{
				index++;
				if (index == 1) continue; //skip header
				DateTime date = DateTime.ParseExact(line[0], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
				double value = Double.Parse(line[1], System.Globalization.CultureInfo.InvariantCulture);
				result.Add(new LemonAtDate(date, value));
			}
			return result;
		}
		public static void WriteToFile(IEnumerable<LemonAtDate> lemons, string filename)
		{
			//Write to file
			using (var sw = new System.IO.StreamWriter(filename))
			{
				foreach (LemonAtDate lemon in lemons)
				{
					sw.WriteLine("Date,Lemon");//Header
					string date = lemon.Date.ToString("yyyy-MM-dd");
					string value = lemon.Value.ToString();
					string line = string.Format("{0},{1}", date, value);
					sw.WriteLine(line);
				}
			}
		}
	}
	static void Main(string[] args)
	{
		//Load first file
		List<LemonAtDate> firstCsv = LemonAtDate.LoadFromFile("first.csv");
		//Load second file
		List<LemonAtDate> secondCsv = LemonAtDate.LoadFromFile("second.csv");
		//We need at least two rows
		if (firstCsv.Count >= 2)
		{
			//Penultimate row in first file
			LemonAtDate lemonSecondLast = firstCsv[firstCsv.Count - 2];
			//Find the value 19 in the second file
			LemonAtDate lemonValue19 = secondCsv.Where(x => x.Value == 19).FirstOrDefault();
			//Value found
			if (lemonValue19 != null)
			{
				double delta = lemonSecondLast.Value - lemonValue19.Value;
				//Get the items between the dates and add the delta
				DateTime dateStart = new DateTime(1975, 1, 3);
				DateTime dateEnd = new DateTime(1975, 1, 9);
				IEnumerable<LemonAtDate> secondFileSelection = secondCsv.Where(x => x.Date >= dateStart && x.Date <= dateEnd)
															  .Select(x => { x.Value += delta; return x; });
				//Create third CSV
				List<LemonAtDate> thirdCsv = new List<LemonAtDate>();
				//Add the rows from the first file until 1975-01-02
				DateTime threshold = new DateTime(1975, 1, 2);
				thirdCsv.AddRange(firstCsv.Where(x => x.Date <= threshold));
				//Add the rows from the second file
				thirdCsv.AddRange(secondFileSelection);
				//Write to file
				LemonAtDate.WriteToFile(thirdCsv, "third.csv");
			}
		}
	}
