                        int column = 1;
                        foreach (DataColumn c in dataTable.Columns)
                        {
                            //Ninth row, starting from the first cell
                            ws.Cells[10, column] = c.ColumnName;
                            column++;
                        }
                        // Create a 2D array with the data from the data table
                        int i = 0;
                        string[,] data = new string[dataTable.Rows.Count, dataTable.Columns.Count];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int j = 0;
                            foreach (DataColumn c in dataTable.Columns)
                            {
                                data[i, j] = row[c].ToString();
                                j++;
                            }
                            i++;
                        }
                        // Set the range value to the 2D array in Excel (10th row, starting from 1st cell)
                        ws.Range[ws.Cells[11, 1], ws.Cells[dataTable.Rows.Count + 11, dataTable.Columns.Count]].Value = data;
