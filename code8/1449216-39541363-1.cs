    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("TestName")) // LocCode
                {
                    if (e.Value != null && e.Value.ToString() != "") // Check for extra line
                    {
                        string a = dt.Rows[e.RowIndex]["Color"].ToString(); //current row's Color column value.
                        e.CellStyle.BackColor = Color.FromName(a); // color as backcolor
                    }
                   
                }
            }
