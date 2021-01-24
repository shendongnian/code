    var list = new List<dynamic>();
    dynamic e1 = new ExpandoObject();
    e1.col1 = "New val 1";
    e1.col2 = "New val 2";
    e1.col3 = 20;
    list.Add(e1);
    dynamic e2 = new ExpandoObject();
    e2.col1 = "New val 1";
    e2.col2 = "New val 3";
    e2.col3 = 10;
    list.Add(e2);
    foreach (var group in list
        .OrderBy(e => e.col1)
        .GroupBy(o => o.col1))
    {
        Debug.WriteLine((string)group.Key);
        var sum = 0;
        foreach (var item in group)
        {
            Debug.WriteLine("    " + (string)item.col2);
            sum += item.col3;
        }
        Debug.WriteLine("Total: " + sum);
    }
