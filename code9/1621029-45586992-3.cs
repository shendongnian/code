    var source597ColsTable = new DataTable("Source");
        
    for (var i = 0; i <= 596; i++)
    {
         source597ColsTable.Columns.Add(new DataColumn("Column" + i , typeof(string)));
    }
        
    DataRow newRow = source597ColsTable.NewRow();
    source597ColsTable.Rows.Add(newRow);
                    
    var cols0To199Table = source597ColsTable.Clone();
    var cols200To399Table = source597ColsTable.Clone();
    var cols400To596Table = source597ColsTable.Clone();
