    static void orderArray(int[] array, string op)
    {
    	if (op == "UpSortOption")
    	{
    		Array.Sort(array);
    		foreach (int number in array)
    		{
    			Console.Write(number + " ");
    		}
    	}
    	else
    	{
    		Array.Sort(array);
    		Array.Reverse(array);
    		foreach (int number in array)
    		{
    			Console.Write(number + " ");
    		}
    	}
    }
