    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {           
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 )
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[e.ColumnIndex];              
                if (string.IsNullOrEmpty((cell.Value).ToString())) MessageBox.Show("What you want");
            }
        }
