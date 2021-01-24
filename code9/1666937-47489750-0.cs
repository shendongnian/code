    private static double? FindNearest(IEnumerable<double> arr, double d)
    {
        var minDist = double.MaxValue;
        double? minValue = null;
    
        foreach (var x in arr)
        {
            var dist = Math.Abs(x - d);
            if (dist < minDist)
            {
                minDist = dist;
                minValue = x;
            }
        }
        return minValue;
    }
