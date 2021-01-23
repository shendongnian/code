	for(int i = 0; i < 3; i++)
	{
		int Avg = 0;
		for(int x = 0; x < 3; x++)
		{
			Console.Write(number[x, i] + " ");
			Avg += number[x, i];
		}
		Avg = Avg / 3;
		Console.Write("Average is" + Avg);
		Console.WriteLine(" ");
		Console.ReadLine();
	}
