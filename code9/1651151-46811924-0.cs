    // IEnumerable<LogItem>.Select(...) creates an IEnumerable which references the array,
    //   and performs the selection and conversion on each call to MoveNext().
    
    graph.Series[0].Points.DataBind(
        results.Select(l => new { X = l.DateTime, Y = l.OilCondition.Value }),
        "X",
        "Y",
        string.Empty);
