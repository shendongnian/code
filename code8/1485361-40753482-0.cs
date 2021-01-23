	IEnumerable<string> EnumeratePermutations(int digits, int length)
	{
		var data = new char[length];
		for (int i = 0; i < data.Length; ++i)
		{
			data[i] = '0';
		}
		
		while (true)
		{
			yield return new string(data);
			
			char maxChar = (char)('0' + digits);
			
			for (int index = length - 1; index >= 0; --index)
			{
				if (++data[index] == maxChar)
				{
					for (int i = index; i < data.Length; ++i)
					{
						data[i] = '0';
					}
					
					if (index == 0)
					{
						yield break;
					}
				}
				else
				{
					break;
				}
			}
		}
	}
