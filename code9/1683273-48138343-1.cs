	using System.Collections;
	using System.Collections.Generic;
...
	public double Pow(double num, int pow)
	{
		var sequence = Enumerable.Repeat(num, pow);
		if (pow > 0)
		{
			return sequence.Aggregate(1, (accumulate, current) => accumulate * current);
		}
		else if (pow < 0)
		{
			return sequence.Aggregate(1, (accumulate, current) => accumulate / current);
		}
		else
		{
			return 1;
		}
	}
