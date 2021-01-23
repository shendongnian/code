                    string html = "<table>";
                    //add header row
                    html += "<tr>";
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                        html += "<td>" + ds.Tables[0].Columns[i].ColumnName + "</td>";
                    html += "</tr>";
                    //add rows
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        html += "<tr>";
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                            html += "<td>" + ds.Tables[0].Rows[i][j].ToString() + "</td>";
                        html += "</tr>";
                    }
                    html += "</table>";
