    protected void AddHyperLink(TableCell cell, string strURL)
    {
        HyperLink hl = new HyperLink();
        hl.Text = cell.Text;
        hl.Font.Underline = true;
        hl.Target = "_blank";
        hl.NavigateUrl = strURL;
        hl.Attributes.Add("style", "color:Black;");
        cell.Controls.Add(hl);
    }
    protected void AddAllLinks(GridView gridView, GridViewRowEventArgs e, Dictionary<string, string> urls)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
            {
                var key = GridView1.HeaderRow.Cells[i].Text;
                string url;
                if (urls.TryGetValue(key, out url))
                {
                    AddHyperLink(e.Row.Cells[i], url);
                }
            }
        }
    }
    static readonly Dictionary<string, string> headersToUrls = new Dictionary<string, string>
    {
        {  "Department", "DepUrl" },
        { "EmployeeID", "EmpURL" }
    };
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        AddAllLinks(GridView1, e, headersToUrls);
    }
