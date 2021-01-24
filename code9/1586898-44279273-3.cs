    if (!grid_summary.Rows[i].Cells[j].Text.Equals("&nbsp;"))
    {
        string columnValueDecode = HttpUtility.HtmlDecode(grid_summary.Rows[i].Cells[j].Text);
        columnValueDecode = columnValueDecode.Trim().Replace(" ", "").Replace("\t", "").Replace("\n", "").Replace("\r", "");
        sum += Convert.ToInt32(columnValueDecode);
    }
