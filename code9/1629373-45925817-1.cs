    var result = dsvoucherget.Tables[0].AsEnumerable().Where(x => x["RegnNo"].ToString() == "EMO1224");
    if (result.Any())
    {
        DataTable tbl = result.CopyToDataTable();
    }
