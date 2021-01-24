    private static double? FindNearestValue(IEnumerable<double> arr, double d)
    {
        var minDist = double.MaxValue;
        double? nearestValue = null;
    
        foreach (var x in arr)
        {
            var dist = Math.Abs(x - d);
            if (dist < minDist)
            {
                minDist = dist;
                nearestValue = x;
            }
        }
        return nearestValue;
    }
