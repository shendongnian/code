    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvResults.SelectedRows.Count > 0)
        {
         dgvResults.SelectedRows[0].Cells["yourColumnName"].Value.ToString();
        }
    }
