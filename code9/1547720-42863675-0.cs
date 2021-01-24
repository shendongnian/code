	while(num1<knizka.Length)
	{
		if (chars[num]==knizka[num1])
		{
			numOfLet[num]++;
			num1++;
			num++;
			if (num>=numOfLet.Length)
			{
				num = 0;
			}   
		}
		else
		{
			num++;
			
			if (num>=numOfLet.Length)
			{
				num = 0;
				num1++;
			}   
		}
	}
