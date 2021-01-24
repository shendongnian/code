	foreach (object value in Num)
	{
		int intvalue = 0;
		if (Int32.TryParse(value.ToString(), out intvalue)
		{
			if (intvalue % 2 != 0)
			{
				odd.Add(intvalue);
			}
			else
			{
				even.Add(intvalue);
			}
		}
	}
