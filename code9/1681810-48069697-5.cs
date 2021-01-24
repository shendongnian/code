		public void Run()
		{
			var members = GetMergedList();
			foreach (var m in members)
			{
				Console.WriteLine("{0}\t{1}\r{2}\t{3:0.00}", m.Name, m.Week, m.Discount, m.Charge);
			}
		}
		
