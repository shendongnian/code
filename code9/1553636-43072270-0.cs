    void Insert (Dictionary <string, SqlType> cols, Object [] objects)
    {
        string colNames = string.Join (",", cols.Keys);
        string paramNames = string.Join (",", cols.Keys.Select (c=>"@"+c));
        using (var command = new SqlCommand(@"INSERT INTO Table1 (" + colNames + 
               ") VALUES (" + paramNames + ")",conn))
        {
              foreach (var col in cols)
              {
                 command.Params.Add("@" + col.Key, col.Value);
              }
              foreach(var o in objects)
              {
                // Here you would have to list them all unless
                // your object o is a Dictionary<string, object>.
                command.Params["@param1"].Value = o.Param1;
                command.Params["@param2"].Value = o.Param2;
                command.Params["@param3"].Value = o.Param3;
                ...
                command.ExecuteNonQuery();
              }
         }
    }
