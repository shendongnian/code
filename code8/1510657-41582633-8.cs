    class DataPoint
    {
        decimal Value { get; set; }
        int Rank { get; set; }
    }
    var dataPointsPreservingOrder = data.Select(x => new DataPoint {Value = x}).ToList();
    var sortedDescending = dataPointsPreservingOrder.OrderByDescending(x => x.Value).ToList();
    var epsilon = 1E-15; //use a value that makes sense here
    int rank = 0;
    double? currentValue = null;
    foreach(var x in sortedDescending)
    {
        if(currentValue == null || Math.Abs(x.Value - currentValue.Value) > epsilon) 
        {
            currentValue = x.Value;
            ++rank;
        }
        x.Rank = rank;
    }
