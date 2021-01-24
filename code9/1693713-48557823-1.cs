    IExcelDataReader excel;
    DataSet ds;
    using (var fs = File.OpenRead("C://somepath"))
    {
        excel = ExcelReaderFactory.CreateOpenXmlReader(fs, null, { Password = "somepass" });
        ds = excel.AsDataSet();
    }
    foreach (DataTable dt in ds.Tables)
    {
        var numberOfRows = dt.Rows.Count;
        var numberOfColumns = dt.Columns.Count;
    }
