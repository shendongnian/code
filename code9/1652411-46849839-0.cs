    DataSet loDs = new DataSet();
    loDs.Tables.Add(new DataTable("Table 3"));
    loDs.Tables.Add(new DataTable("Table 2"));
    loDs.Tables.Add(new DataTable("Table 1"));
    loDs.Tables.Add(new DataTable("Table 4"));
    
    foreach (DataTable loDt in loDs.Tables.Cast<DataTable>().OrderBy(item => item.TableName))
        Console.WriteLine(loDt.TableName);
