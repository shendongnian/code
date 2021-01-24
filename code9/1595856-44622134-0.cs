	List<double> list =
		File
			.ReadAllLines(ofd.FileName)
			.SelectMany(line => line.Split(' '))
			.Select(double.Parse)
			.OrderBy(x => x)
			.ToList();
	foreach (double x in list)
	{
		listBox1.Items.Add(x);
	}
