     private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                //Enter your own column index here
                if(e.ColumnIndex == 0)
                foreach(DataGridViewRow row in dataGridView1.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                {
                        //Check if the cell type is of a CheckBoxCell
                    if (cell.GetType() == typeof(DataGridViewCheckBoxCell))
                    {
                        DataGridViewCheckBoxCell c = (DataGridViewCheckBoxCell)cell;
                        c.TrueValue = "T";
                        c.FalseValue = "F";
                        if (c.Value == c.FalseValue|| c.Value == null )
                        c.Value = c.TrueValue;
                        else
                            c.Value = c.FalseValue;
                    }
                }
                dataGridView1.RefreshEdit();
            }
