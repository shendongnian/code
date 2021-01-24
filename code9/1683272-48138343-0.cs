	public double Pow(double num, int pow)
	{
		double result = 1;
		if (pow > 0)
		{
			for (int i = 1; i <= pow; ++i)
			{
				result *= num;
			}
		}
		else if (pow < 0)
		{
			for (int i = -1; i >= pow; --i)
			{
				result /= num;
			}
		}
		return result;
	}
