         foreach (DataRow row in dt.Rows)
         {
             StringBuilder csv = new StringBuilder();
             foreach (DataColumn column in dt.Columns)
             {
                 csv.Append(row[column.ColumnName].ToString().Replace(",", ";") + ',');
             }
             csv.AppendLine();
             Response.Write(csv.ToString());
         }
