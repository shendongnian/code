    DataTable dt = new DataTable();
    dt.Columns.Add("StartTime");
    dt.Columns.Add("EndTime");
    dt.Columns.Add("Message");
    foreach (var data in pNodelist)
    {
    if (data.HasAttributes == true)
    dt.Rows.Add(data.FirstAttribute.Value, data.LastAttribute.Value, data.Value);
    }
