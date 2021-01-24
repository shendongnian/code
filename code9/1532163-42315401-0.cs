    private void Grid_Log_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (Grid_Log.Columns[e.ColumnIndex].Name.Equals("MStatus") || Grid_Log.Columns[e.ColumnIndex].Name.Equals("Status"))
                {
                    if (e.Value!=null)
                    {
                        if (e.Value.Equals("SUCCESS") || e.Value.Equals("Closed"))
                        {
                            //e.CellStyle.BackColor = Color.Red;
                            //e.CellStyle.SelectionBackColor = Color.DarkRed;
                            //Grid_Log.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                            Grid_Log.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                }
            }
