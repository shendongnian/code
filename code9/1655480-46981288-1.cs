            private void dgvSCXTableView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex >= 0)
            {
            }
        }
