	while (!over)
	{
		var typedName =Console.ReadLine();
		if(typedName == "0")
		{
			over = true;
		}else
		{
			Console.WriteLine("Enter a  name... ");
			names.Add(Console.ReadLine());
		}
		...
	}
