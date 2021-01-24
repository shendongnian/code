    public static string ConvertDataTableToHTML(DataTable dt)
    {
        StringBuilder builder = new StringBuilder();
        
        //add header row
        builder.Append("<table border='1'><thead><tr>");
        foreach (DataColumn col in dt.Columns)
        {
            builder.Append("<td>");
            builder.Append(col.ColumnName);
            builder.Append("</td>");
        }
    
        builder.Append("</tr></thead><tbody>");
    
        //add rows
        string sub = "";
        ...
        builder.Append("</tbody></table>");
        return builder.ToString();
    }
