    foreach (DataColumn column in dt.Columns)
    {
        html.Append("<td>");
        html.Append(column.ColumnName == "status" 
    		? (row[column.ColumnName].ToString() != "0" 
    			? row[column.ColumnName].ToString() 
    			: "Pending") 
    		: row[column.ColumnName].ToString());   
        html.Append("</td>");
    }
