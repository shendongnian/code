    StringBuilder str = new StringBuilder();
    foreach (var s in myDict)
    {
        foreach (var i in s.Value)
        {
            //Key is char, Value is string
            str.Append("(")
               .Append(s.Key)
               .Append(",")
               .Append(i.Key)
               .Append(",")
               .Append(i.Value)
               .Append("),");
        }
    }
    //remove trailing ","
    var s = str.ToString().Trim(",");
