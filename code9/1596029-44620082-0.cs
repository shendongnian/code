	List<Tuple<DateTime, double>> list = new List<Tuple<DateTime, double>>();
	list.Add(Tuple.Create(new DateTime(2017, 1, 1), 64d));
	list.Add(Tuple.Create(new DateTime(2017, 2, 3), 128d));
	list.Add(Tuple.Create(new DateTime(2017, 3, 6), 256d));
	foreach (Tuple<DateTime, double> tuple in list)
	{
		Console.WriteLine("DateTime={0:yyyy/dd/mm}, Double={1}", tuple.Item1, tuple.Item2);
	}
