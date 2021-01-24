    using System.Collections.Generic; // for dictionary
    using System.Text; // for stringbuilder
    // ...
    // create a dictionary then use a literal to make it easier to populate
    Dictionary<string, string> data = new Dictionary<string, string>
    {
        { "entry_date", "SOMEVALUE1" }, 
        { "entry_time", "SOMEVALUE2" }
        // add more params and values here...
    };
    // start our query and params list
    StringBuilder query = new StringBuilder("YOUR QUERY STARTS HERE");
    List<SqlParameter> params = new List<SqlParameter>();
    // iterate over each key/value pair, appending to the query and params list
    foreach (KeyValuePair<string, string> pair in data) {
        query.Append("@" + pair.Key);
        params.Add(new SqlParameter(pair.Key, pair.Value));
    }
