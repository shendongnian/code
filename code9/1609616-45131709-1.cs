    class Car
    {
        Manufacturer Manufacturer { get; set; }
    }
    class Manufacturer
    {
        string ID { get; set; }
    }
    Expression<Func<Car, string>> groupKeySelector = x => x.Manufacturer.ID;
    Expression<Func<ObjectWithRank<Car>, Car>> rankedObjectSelector = x => x.RankedObject;
    var rankedGroupKeySelector = UpdateExpressionRoot(rankedObjectSelector, groupKeySelector);
    //rankedGroupKeySelector.ToString() == "x.RankedObject.Manufacturer.ID"
    //Essentially this replaced ParameterExpression {x} in x.Manufacturer.ID with MemberExpression {x.RankedObject}.
