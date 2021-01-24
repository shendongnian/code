    DataSet loDs = new DataSet();
    
    loDs.Tables.Add(new DataTable("141"));
    loDs.Tables.Add(new DataTable("142"));
    loDs.Tables.Add(new DataTable("143"));
    loDs.Tables.Add(new DataTable("145"));
    loDs.Tables.Add(new DataTable("144"));
    
    foreach (DataTable loDt in loDs.Tables.Cast<DataTable>().OrderBy(item => int.Parse(item.TableName)))
        Console.WriteLine(loDt.TableName);
