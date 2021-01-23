    List<TableColumns> dataTableList = new List<TableColumns>();
    dataTableList = (
        from DataRow dr in myDataTable.Rows  
        select new TableClass()  
        {  
            Column1 = int.Parse(dr["Column1"]),
            Column2 = dr["Column2"].ToString(),  
            Column3 = dr["Column3"].ToString(),  
            Column4 = dr["Column4"].ToString() //etc...
        }).ToList();  
