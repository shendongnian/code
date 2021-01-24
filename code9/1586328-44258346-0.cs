    double total = 10.0;
    double numberOf = 0.0;
    var tot = total / numberOf;
    // check for IsInfinity, IsPositiveInfinity,
    // IsNegativeInfinity separately and take action appropriately if need be
    if (double.IsInfinity(tot) || double.IsPositiveInfinity(tot) || 
    double.IsNegativeInfinity(tot))
    {
        ...
    }
