    if (ds != null)
    {
        if (ds.Tables.Count >0 )
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ConvertDataSetTableToHTML(ds.Tables[0]);
            }
        }
    }
    public static string ConvertDataSetTableToHTML(DataTable dt)
    {
        string html = "<table>";
        //add header row
        html += "<tr>";
        for(int i=0;i<dt.Columns.Count;i++)
            html+="<td>"+dt.Columns[i].ColumnName+"</td>";
        html += "</tr>";
        //add rows
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            html += "<tr>";
            for (int j = 0; j< dt.Columns.Count; j++)
                html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
            html += "</tr>";
        }
        html += "</table>";
        return html;
    }
