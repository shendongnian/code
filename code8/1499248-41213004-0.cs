    HtmlNodeCollection tables = pag1.Html.SelectNodes("//table[@id='data']");
    
    DataTable tb = new DataTable();
    HtmlNodeCollection rows = tables[0].SelectNodes("tr");
    
    // create the columns
    HtmlNodeCollection cols = rows[0].SelectNodes("th");
    if (cols != null)
    {
        for (int j = 0; j <= cols.Count - 1; j++)
        {
            tb.Columns.Add(cols[j].InnerText);
        }
    }
    
    // Now fill the table
    for (int i = 0; i <= rows.Count - 1; i++)
    {
        var newRow = tb.NewRow();
        HtmlNodeCollection cols = rows[i].SelectNodes("td");
        if (cols != null)
        {
            for (int j = 0; j <= cols.Count - 1; j++)
            {
                newRow[j] = cols[j].InnerText;
            }
    
        }
    
        // add the row to table
        tb.Rows.Add(newRow);
    }
    GridView1.DataSource = tb;
    GridView1.DataBind();
