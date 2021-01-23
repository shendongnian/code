    public static string Split(int number)
	{
		var b = new StringBuilder();
		while(number > 0)
		{
			var v = number % 256;
			if(b.Length > 0)
				b.Append(" ");
			b.Append("+ ");
			b.Append(v);
			number /= 256;
		}
		
		return b.ToString();
	}
