    var args = new System.Dynamic.ExpandoObject();
    args.SomeString = "hello";
    args.SomeInt = 32;
    args.SomeBool = false;
    funcVars(args);
    public static string funcVars(ExpandoObject inputs)
    {
        var sb = new StringBuilder();
        foreach (KeyValuePair<string, object> kvp in inputs)      
        {
            sb.Append(String.Format("{0} = {1}", kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }
