    string[] firstCols = dtmasterdata.Columns
                             .Cast<DataColumn>()
                             .Take(255)
                             .Select(x => x.ColumnName).ToArray();
    string[] secondCols = dtmasterdata.Columns
                              .Cast<DataColumn>()
                              .Skip(255)
                              .Take(255)
                              .Select(x => x.ColumnName).ToArray();
    string[] thirdCols = dtmasterdata.Columns
                             .Cast<DataColumn>()
                             .Skip(510)
                             .Select(x => x.ColumnName).ToArray();
    DataTable t1 = dtmasterdata.DefaultView.ToTable("Master_1", false, firstCols);
    DataTable t2 = dtmasterdata.DefaultView.ToTable("Master_2", false, secondCols);
    DataTable t3 = dtmasterdata.DefaultView.ToTable("Master_3", false, thirdCols);
