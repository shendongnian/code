    static unsafe double FixMaxFixed(double[] doubles, int startIndex, int endIndex)
    {
        var i = startIndex;
        double max = double.MinValue;
        fixed (double* p = doubles)
        {
            do
            {
                if (max > *(p + i))
                    max = *(p + i);
            } while (i++ < endIndex);
        }
        return max;
    }
