    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
                {
                    if ((e.ColumnIndex == this.dataGridView1.Columns["NameID"].Index))
                    {
                        //column name
                        DataGridViewCell cell =
                            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        //column id
                        DataGridViewCell cell1 =
                          this.dataGridView1.Rows[e.RowIndex].Cells["NameID"];
        
                        cell.ToolTipText = "DBC";
        
                        if (cell1.Equals("0"))
                        {
                            cell.ToolTipText = "Please update NameID as required, To know more click Help icon";
                        }
                        else if (cell1.Equals("1"))
                        {
                            cell.ToolTipText = "DBC";
                        }
                        else if (cell1.Equals("2"))
                        {
                            cell.ToolTipText = "XYZ";
                        }
                        else if (cell1.Equals("3"))
                        {
                            cell.ToolTipText = "ABC";
                        }
        
                    }
        }
