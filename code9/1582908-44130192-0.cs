    private void createTabel()
        {
            StringBuilder html = new StringBuilder();
    
            html.Append("<table>");
    
            //Header Row erstellen.
            html.Append("<tr>");
            foreach (DataColumn column in dataTable.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");
    
            //Erstellen der Rows.
            foreach (DataRow row in dataTable.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dataTable.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
    
            html.Append("</table>");
    
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }
