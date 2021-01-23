    private static int[] RemoveSubArray()
    {
        int[] greaterArray = {8, 3, 4, 5, 9, 12, 6, 3, 5, 3, 4, 5};
        int[] lesserArray = {3,4,5};
        if (lesserArray == null || lesserArray.Length == 0)
        {
            return greaterArray;
        }
        int[] allIndex = greaterArray.Select((b,i) => b == lesserArray[0] ? i : -1).Where(i => i != -1).ToArray();
        for (int index = 0; index < allIndex.Length; index++)
        {
            int count = 0;
            for (int x = 1; x < allIndex.Length; x++)
            {
                if (greaterArray[allIndex[index] + x] == lesserArray[x])
                {
                    count++;
                }
            }
            if (count == allIndex.Length - 1)
            {
                for (int inner = 0; inner < allIndex.Length; inner++)
                {
                    greaterArray[allIndex[index] + inner] = 0;
                }
            }
        }
        return greaterArray = greaterArray.Where(i => i != 0).ToArray();
    }
