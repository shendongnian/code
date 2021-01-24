                    var href = true;              
                    foreach(DataColumn column in new_dt.Columns)
                    {
                        html.Append("<td>");
                        if (href)
                        {
                            href = false;
                            html.Append("<a href='/default.aspx?guid=" + Session["guid"] + "&membid=" + row[column.ColumnName]  +"'>");
                            html.Append(row[column.ColumnName]);
                            html.Append("</a></td>");
                        }                        
                        else
                        {
                            html.Append(row[column.ColumnName]);
                            btnValue.Append(row[column.ColumnName]);
                            btnValue.Append(";");
                            html.Append("</td>");
                        }
                        
                    }
