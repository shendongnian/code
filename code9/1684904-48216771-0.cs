    public static int[] UniformNormalization(this Random r, int valueCount, int valueSum)
    {
        var ret = new int[valueCount];
        long sum = 0;
        for (int i = 0; i < valueCount; i++)
        {
            var next = r.Next(0, valueSum);
            ret[i] = next;
            sum += next;
        }
        for (int i = 0; i < valueCount; i++)
        {
            ret[i] = (int)((ret[i] * valueSum) / sum);
        }
        return ret;
    }
