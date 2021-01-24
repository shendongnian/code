    List<string> ColumnNames = names.Keys.ToList()
    List<string> ValueNames = names.Values.ToList();
    List<string> RevValueNames = new List<string>();
    ValueNames.ForEach(x => RevValueNames.Add("'" + x + "'"));
    string Query = string.Format("insert into MyTable ({0}) values ({1})", string.Join(",", ColumnNames), string.Join(",", RevValueNames));
                    command.CommandText = Query;
