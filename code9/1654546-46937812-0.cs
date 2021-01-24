	public static int[] WithoutZeros (int[] input)
	{
		int zerosCount = 0; // we need to count how many zeros are in the input array
		
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] == 0) zerosCount = zerosCount + 1;
		}
	
		// now we know number of zeros, so we can create output array
		// which will be smaller than then input array (or not, if we don't have any zeros in the input array)
		
		int[] output = new int[input.Length - zerosCount]; // can be smaller, equal, or even empty
	
		// no we need to populate non-zero values from the input array to the output array
		
		int indexInOutputArray = 0;
		
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] != 0)
			{
				output[indexInOutputArray] = input[i];
				
				indexInOutputArray = indexInOutputArray + 1;
			}
		}
		
		return output;
	}
