    int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 1207, 7, 8, 9, 1803, 10, 11, 9000, 9001 };
    // Sort the array
    Array.Sort(arr);
    // Start at the beginning and check if the index matches the actual number.
    // Computer begins at 0, so fix that
    for (int index=0;index<arr.Length; index++)
    {
    	if (arr[index] != index+1)
    	{
    		Console.WriteLine("Next ID is " +(index+1));
    		break;
    	}
    }
