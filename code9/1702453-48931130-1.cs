    var sb = new StringBuilder();
    var headers = dGV.Columns.Cast<DataGridViewColumn>();
    sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        var cells = row.Cells.Cast<DataGridViewCell>();
        string temp string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray())
        temp = temp.Replace(",","");
        temp = temp.Replace("\"","");
        if(temp.Length > 0)
        {
          sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
        }
    }
