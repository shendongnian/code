    DataTable table = new DataTable();
    table.TableName = "LookupData";
    XLWorkbook wb = new XLWorkbook();
    wb.Worksheets.Add(table).Cell(1, 1).SetValue("Hello World");
    // no exception with below line:
    //wb.Worksheets.Add("table").Cell(1, 1).SetValue("Hello World");
    using (MemoryStream memoryStream = new MemoryStream())
    {
    	wb.SaveAs(memoryStream); // IndexOutOfRangeException here
    	memoryStream.WriteTo(Response.Body);
    	memoryStream.Close();
    }
