    foreach (DataColumn column in dt.Columns)
    {
    	html.Append("<td>");
        if(row[column.ColumnName].ToString() != "0")   
         	html.Append(row[column.ColumnName]);
        else
         	html.Append("Zero Value");   
    	html.Append("</td>");
    }
