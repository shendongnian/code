                var data = new DataTable("Table1");
                data.Columns.Add(new DataColumn("Username", typeof(string)));
                data.Columns.Add(new DataColumn("UserId", typeof(int)));
    
                var row = data.NewRow();
                row["Username"] = "User1";
                row["Userid"] = 12356;
                data.Rows.Add(row);
    
                data.AcceptChanges();
    
                var originalTable = data.Copy();
    
                var rowToEdit = data.Rows[0];
                rowToEdit["Username"] = "User2";
                
                var rowPos = 0;
    
                foreach (DataRow dr in data.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {
                        foreach (DataColumn c in dr.Table.Columns)
                        {
                            if (dr.ItemArray[c.Ordinal] != originalTable.Rows[rowPos].ItemArray[c.Ordinal] )
                            {
                                //Show Changed value
                                var x = originalTable.Rows[rowPos].ItemArray[c.Ordinal];
                            }
                        }
                    }
                    rowPos++;
                }
