	object[,] obj = new object[,] { { 1.1, 2.1, 2.3 },{ 3.2, 4.3, 5.4 } };
	decimal[,] result = new decimal[obj.GetLength(0), obj.GetLength(1)];
	for (int i = 0; i < obj.GetLength(0); i++)
	{
		for (int j = 0; j < obj.GetLength(1); j++)
		{
			try
			{
				result[i, j] = Convert.ToDecimal(obj[i, j]);
			}
			catch (Exception)
			{
				result[i, j] = new decimal(0.0);
			}
		}
	}
