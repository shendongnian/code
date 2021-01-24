    DataSet dataset = new DataSet();
    dataset.Tables.Add(new DataTable("Shoreline"));
    dataset.Tables.Add(new DataTable("Test"));
    List<DataTable> tables = (from DataTable datatable in dataset.Tables
                              where datatable.TableName.Contains("Shoreline")
                              select datatable).ToList();
