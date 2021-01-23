    static T[] ConcatOneAfterOne<T>(params T[][] arrays)
	{
		int outputArrayLength = 0;
		for (int i = 0; i < arrays.Length; i++)
		{
			outputArrayLength += arrays[i].Length;
		}
		T[] output = new T[outputArrayLength];
		int outputIndex = 0;
		int sourceIndex = 0;
		while (outputIndex != outputArrayLength)
		{
			for (int arrayIndex = 0; arrayIndex < arrays.Length; arrayIndex++)
			{
				if (sourceIndex < arrays[arrayIndex].Length)
				{
					output[outputIndex++] = arrays[arrayIndex][sourceIndex];
				}
			}
			sourceIndex++;
		}
		return output;
	}
	[Test]
	static void ConcatOneAfterOneTest()
	{
		int[] result = ConcatOneAfterOne(new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 });
		CollectionAssert.AreEqual(new int[] { 1, 3, 5, 2, 4, 6 }, result);
	}
