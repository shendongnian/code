	Console.WriteLine("Enter the Limit : ");
	int m = int.Parse(Console.ReadLine());
	Console.WriteLine("Enter the Numbers :");
	int count =
		Enumerable
			.Range(0, m)
			.Select(n => Console.ReadLine())
			.Where(x => x == "1")
			.Count();
	Console.WriteLine("Number of 1's in the Entered Number : " + count);
	Console.ReadLine();
