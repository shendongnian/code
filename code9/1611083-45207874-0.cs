        //Populating a DataTable from database.
        DataTable dt = this.GetData();
 
        //Building an HTML string.
        StringBuilder html = new StringBuilder();
 
        //Table start.
        html.Append("<table border = '1'>");
 
        //Building the Header row.
        html.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
            html.Append("<th>");
            html.Append(column.ColumnName);
            html.Append("</th>");
        }
        html.Append("</tr>");
 
        //Building the Data rows.
        foreach (DataRow row in dt.Rows)
        {
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<td>");
               html.Append(row[column.ColumnName]);
                html.Append("</td>");
            }
            html.Append("</tr>");
        }
 
        //Table end.
        html.Append("</table>");
 
        //Append the HTML string to Placeholder.
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
