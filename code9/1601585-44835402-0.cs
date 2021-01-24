		var last = DateTime.MinValue;
		foreach (var f in sample.OrderBy(x => x.DueDate))
		{
			if (f.DueDate.Equals(last))
				Console.WriteLine("{0}\t{1}\t{2}", "SKIP DATE", f.Desc, f.Amount);
			else
			{
				Console.WriteLine("{0}\t{1}\t{2}", f.DueDate.ToShortDateString(), f.Desc, f.Amount);
				last = f.DueDate;
			}
		}
