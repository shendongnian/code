    foreach (DataColumn column in dt.Columns)
         {
          html.Append("<td>");
          if (row[column.ColumnName].ToString() != "status" && row[column.ColumnName].ToString() != "0")
                html.Append(row[column.ColumnName]);
                else
                html.Append("Pending");
                html.Append("</td>");
         }
