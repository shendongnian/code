    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                    int iRow = dataGridView1.CurrentCell.RowIndex;
                    if (iColumn == dataGridView1.Columns.Count - 1)
                        dataGridView1.CurrentCell = dataGridView1[0, iRow + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[iColumn + 1, iRow];
                }
            }
            catch { }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Cells[0];
            }
            else
            {
                SendKeys.Send("{UP}");
                SendKeys.Send("{left}");
            }
        }
