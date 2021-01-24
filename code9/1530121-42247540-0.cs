    private void btnTest_Click_1(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dgvReceivingproducts.Rows)
        {
            if (row.Cells[7].Value != null && row.Cells[8].Value != null && row.Cells[9].Value != null)
            {
                row.Cells[X].Value = "enabled";
            }
            else
            {
                row.Cells[X].Value = "disabled";
            }
        }           
    }
