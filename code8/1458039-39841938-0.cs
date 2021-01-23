    DataTable dt = ...
    // Your custom date format.
    string format = "yyyy-MM-dd";
    var sb = new StringBuilder();
    foreach (DataRow row in dt.Rows)
    {
        sb.AppendLine(string.Join(",", row.ItemArray.Select(item =>
            item is DateTime ? ((DateTime)item).ToString(format) : item.ToString()
        )));
    }
    File.WriteAllText("test.csv", sb.ToString());
