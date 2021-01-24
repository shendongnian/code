    void dataGridResult_SelectionChanged(object sender, EventArgs e)
        {
            if (_MainForm.dataGridResult.SelectedRows.Count > 0)
            {
                var selectedRowsCount = _MainForm.dataGridResult.SelectedRows[0];
                string name = Convert.ToString(selectedRowsCount.Cells[0].Value);
        }
