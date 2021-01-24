    if (!grid_summary.Rows[i].Cells[j].Text.Equals("&nbsp;"))
    {
        string columnValueDecode = HttpUtility.HtmlDecode(grid_summary.Rows[i].Cells[j].Text);
        columnValueDecode.Replace(" ", "");
        columnValueDecode.Replace(" ", "").Replace("\t", "").Replace("\n", "").Replace("\r", "");
        columnValueDecode.Trim();
        sum += Convert.ToInt32(columnValueDecode);
    }
