    //fill the datatable
    DataTable dt = GetTable();
    
    //filter the datatable with Linq
    var filteredRows = dt.AsEnumerable().Where(x => x.Field<Info>("Patient").Address == "India");
    
    //check if there are any rows before calling CopyToDataTable,
    //otherwise you'll get a "The source contains no DataRows" error
    if (filteredRows.Any())
    {
        DataTable dtFiltered = filteredRows.CopyToDataTable();
    }
