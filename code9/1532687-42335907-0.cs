	int step = 4;
	string delimiter = " ";
	for(int i = 0; i < BytArr.Length;i += step)
	{
		for(int j = 0; j < step; j++)
		{
			Console.Write(BytArr[i + j].ToString("X2"));
		}
		Console.Write(delimiter);
	}
