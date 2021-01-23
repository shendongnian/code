	Random random = new Random();
	const string numchars = "0123456789";
	const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	List<string> randStr = new List<string>();
	for(int i = 0; i <= 10; i++)
	{
		string AlphaRandom = new string(Enumerable.Repeat(chars, 1)
		  .Select(s => s[random.Next(s.Length)]).ToArray());
		string NumberRandom = new string(Enumerable.Repeat(numchars, 1)
		  .Select(s => s[random.Next(s.Length)]).ToArray());
		if(randStr.Contains(AlphaRandom + NumberRandom))
		{
			i--;
		}
		else
		{
			randStr.Add(AlphaRandom + NumberRandom);
			Console.WriteLine(randStr[i]);
		}
	}
