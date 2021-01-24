    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                if (addedRowIndex != e.RowIndex)
                {
                    e.Cancel = true;
                }
            }
        }
    }
