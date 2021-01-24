    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strMktURL = "http://www.address.com";
            for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
            {
                string strHeaderRow = GridView1.HeaderRow.Cells[i].Text;
                if (strHeaderRow == "ID")
                {
                    if(!string.IsNullOrEmpty(e.Row.Cells[i])) // <- This line
                    {
                        HyperLink hlColumns = AddHyperLink(e.Row.Cells[i], strMktURL);
                    }
                }
            }
        }
    }
