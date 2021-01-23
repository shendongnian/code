     private void dataGridView1_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    "Company Name must not be empty";
                e.Cancel = true;
            }
        }
