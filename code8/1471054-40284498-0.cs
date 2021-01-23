    static int[] Run(int[] greaterArray, int[] lesserArray)
    {
        int[] result = new int[greaterArray.Length];
        int k = 0;
        for (int i = 0; i < greaterArray.Length; )
        {
            if (greaterArray.Skip(i).Take(lesserArray.Length).SequenceEqual(lesserArray))
            {
                i += lesserArray.Length;
            }
            else
            {
                result[k] = greaterArray[i];
                i++;
                k++;
            }           
        }
        return result;
    }
