    DataSet loDs = new DataSet();
    
    loDs.Tables.Add(new DataTable("141"));
    loDs.Tables.Add(new DataTable("142"));
    loDs.Tables.Add(new DataTable("143"));
    loDs.Tables.Add(new DataTable("145"));
    loDs.Tables.Add(new DataTable("144"));
    
    var loSortedDataTableList = loDs.Tables.Cast<DataTable>().OrderBy(item => int.Parse(item.TableName)).ToList();
    loDs.Tables.Clear();
    
    foreach (DataTable loDt in loSortedDataTableList)
    {
        loDs.Tables.Add(loDt);
        Console.WriteLine(loDt.TableName);
    }
