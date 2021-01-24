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
        var actualSum = 0;
        for (int i = 0; i < valueCount; i++)
        {
            actualSum += ret[i] = (int)((ret[i] * valueSum) / sum);
        }
        //Fix integer rounding errors.
        if (valueSum > actualSum)
        {
            for (int i = 0; i < valueSum - actualSum; i++)
            {
                ret[r.Next(0, valueCount)]++;
            }
        }
        return ret;
    }
