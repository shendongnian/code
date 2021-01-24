    static List<int> Distribute(int start, int end, int holders)
    {
        List<int> result = new List<int>();
        // First value will always be the start
        result.Add(start);
        // Calculate a percentage for the middle values
        double range = end - start;
        double step = range / (holders - 1);
        for (int i = 1; i < holders - 1; i++)
        {
            double target = step * i + start;
            result.Add((int)Math.Round(target));
        }
        // Last value is the end
        result.Add(end);
        return result;
    }
