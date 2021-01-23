	public bool TwoDimensionalContains(string[,] inputArray, string comparisonString)
	{            
		for (int i = 0; i < inputArray.GetLength(0); i++)
		{
			for (int j = 0; j < inputArray.GetLength(1); j++)
			{                    
				// If matching element found, return true
				if (comparisonString.Equals(inputArray[i, j]))
					return true;
			}
		}
		// No matchincg element found, return false
		return false;
	}
