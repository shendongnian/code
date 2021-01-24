        private void dgvData_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (dgvData.Rows[e.RowIndex1].Cells[0].Value.ToString() == "Total" ||
                dgvData.Rows[e.RowIndex2].Cells[0].Value.ToString() == "Total")
            {
                if (dgvData.SortOrder == SortOrder.Ascending)
                {
                    e.SortResult = -1;
                }
                else
                {
                    e.SortResult = 1;
                }
                e.Handled = true;
            }
        }
