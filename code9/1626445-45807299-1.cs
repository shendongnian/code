	static string[] Sort(string[] array, ref int counter)
	{
		Array.Sort(array);
		int lowestFilled = -1;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != "")
			{
				if (i - lowestFilled > 1)
				{
					string tmp = array[lowestFilled + 1];
					array[lowestFilled + 1] = array[i];
					array[i] = tmp;
					++lowestFilled;
				}
			}
			if (array[i] != "")
			{
				lowestFilled = i;
			}
		}
		return array;
	}
