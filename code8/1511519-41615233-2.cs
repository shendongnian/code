	var list = new List<double> { 2654, 3727.25, 4800.5, 5873.75, 6947 };
	var min = list.Min();
	var max = list.Max();
	foreach (var d in list)
	{
		var power = Math.Floor(Math.Log10(d));
		var inf = d - d % Math.Pow(10, power); 
		var sup = d + (Math.Pow(10, power) - d % Math.Pow(10, power));
		if (d == min)
		{
			Console.WriteLine("0-" + sup);
		}
		if (d == max)
		{
			Console.WriteLine(">" + sup);
		}
		else
		{
			Console.WriteLine(inf + "-" + sup);
		}
	}
	/*
	Result:
	0-3000
	3000-4000
	4000-5000
	5000-6000
	>7000
	/*  
