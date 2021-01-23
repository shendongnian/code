    var count = dt.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() == dt.AsEnumerable().Count()).Count();
    object result;
    if (count == 1)
        result = dt.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() == dt.AsEnumerable().Count()).First().Key;
    else
        result = "";
