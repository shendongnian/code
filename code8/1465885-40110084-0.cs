    private static int count(int X, int Y, int Z)
    {
        int count = 0;
        var splitZ = split(Z);
        if (splitZ.Count == 0)
        {
            return Y - X + 1; // everything matches an empty Z sequence
        }
        for (int i = X; i <= Y; i++)
        {
            var idigits = split(i);
            int subIndex = 0;
            foreach (var digit in idigits)
            {
                if (splitZ[subIndex] == digit)
                {
                    ++subIndex; // matched digit
                }
                if (subIndex >= splitZ.Count)
                {
                    ++count;
                    break; // matched whole sub-sequence
                }
            }
        }
        return count;
    }
