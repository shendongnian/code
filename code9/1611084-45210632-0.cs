                TableRow tHeaderRow = new TableHeaderRow();
                tHeaderRow.TableSection = TableRowSection.TableHeader;
                testTable.Rows.Add(tHeaderRow);
                foreach (DataColumn column in all("Users").Columns)
                {
                    TableHeaderCell tHeaderCell = new TableHeaderCell();
                    tHeaderCell.Text = column.ColumnName;
                    tHeaderRow.Cells.Add(tHeaderCell);
                }
                foreach( DataRow row in all("Users").Rows)
                {
                    TableRow tRow = new TableRow();
                    testTable.Rows.Add(tRow);
                    foreach (DataColumn column in all("Users").Columns)
                    {
                        TableCell tCell = new TableCell();
                        tCell.Text = row[column.ColumnName].ToString();
                        tRow.Cells.Add(tCell);
                    }
                }
