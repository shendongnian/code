    (double?, double?) AggregateMinMax((double? Min, double? Max) current,
        double next)
    {
        if ((current.Min == null) || (current.Min.Value > next)) {
            return (next, null);
        }
        else if ((current.Max == null) || (next > current.Max.Value)) {
            return (current.Min, next);
        }
        else {
            return current;
        }
    }
    (double? min, double? max) = CutList.OrderBy(value => value.Date).Select(value => value.Value)
        .Aggregate(((double?)null, (double?)null), AggregateMinMax);
