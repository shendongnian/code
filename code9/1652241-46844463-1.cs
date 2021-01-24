    string query = @"select *
                    from SampleTable
                    where @where";
    
    List<Dictionary<string, string>> filters = new List<Dictionary<string, string>>() {
                    new Dictionary<string, string>(){{"ColumnA", "A Value 1"},{"ColumnB", "A Value 2"}},
                    new Dictionary<string, string>(){{"ColumnA", "B Value 1"},{"ColumnB", "B Value 2"}}
                };
    
    var tuple = DapperHelper.ToSqlTuple(filters);
    query = query.Replace("@where", string.IsNullOrEmpty(tuple) ? "1=1" : tuple); //Use 1=1 if tuple is empty or null
    
    var data = con.Query<T>(query).AsList();
