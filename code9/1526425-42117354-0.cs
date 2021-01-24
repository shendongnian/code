    DataTable dt = new DataTable();
    dt.Columns.Add("Title", typeof(string));
    dt.Columns.Add(" ", typeof(string));
    dt.Rows.Add("Value 1", "Value 2");
    dt.Rows.Add("Example 1", "Example 2");
    WriteExcelWithNPOI(dt, "xlsx");
