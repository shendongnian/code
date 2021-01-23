	int num = 12;
	int sum = num;
	int rem = 0;
	bool isitFirstTime = true;
	if (sum > 9)
	{
		if(!isitFirstTime)
		{
			num = sum;
		}
		else
		{
			sum = 0;
		}
		while (num != 0)
		{
			rem = num % 10;
			num = num / 10;
			sum = sum + rem;
		}
		isitFirstTime = false;
	}
	Console.WriteLine(sum);
	
	
