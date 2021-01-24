    IExcelDataReader excel;
    DataSet ds;
    using (var fs = File.OpenRead("C://somepath"))
    {
        excel = ExcelReaderFactory.CreateOpenXmlReader(fs, null, { Password = "somepass" });
        ds = excel.AsDataSet();
    }
    foreach (DataTable dt in ds.Tables)
    {
        for (var i = 0; i<dt.Rows.Count; i++)
        {
            for (var j = 0; j<dt.Columns.Count; j++)
            {
                var cell = dt.Rows[i][j];
                //do what you need with a cell
            }
        }
    }
