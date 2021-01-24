    private void dgvMain_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
        if (IsLoading == true)
            return;
    
        if (e.Column.Index == dgvMain.Columns.Count-1) 
        {
            dgvMain.ColumnWidthChanged -= dgvMain_ColumnWidthChanged;
            if (dgvMain.Width - GetTotalColumnsWidth() <= 200)
            {
                e.Column.Width = e.Column.Width + 20;
                dgvMain.Width = dgvMain.Width + 40;
            }
            dgvMain.ColumnWidthChanged += new DataGridViewColumnEventHandler(dgvMain_ColumnWidthChanged);
        }
    }
    
    private int GetTotalColumnsWidth()
    {
        var result = 0;
        for (int i = 0; i < dgvMain.Columns.Count; i++)
        {
            result += dgvMain.Columns[i].Width;
        }
    
        return result;
    }
