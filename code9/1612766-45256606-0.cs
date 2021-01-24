    private void btnRemove_Click(object sender, EventArgs e)
    {
        foreach (var row in dgvPOScart.SelectedRows)
        {
            // Get the row in dgvProducts and the quantity he'll gain back
            var productRow = dgvPOSproduct.Rows[FindRowIndexByID(row.Cells[0].Value)];
            int qtyToAdd = Convert.ToInt32(row.Cells[4].Value);
            
            // Add the quantity back
            productRow.Cells[5].Value = Convert.ToInt32(productRow.Cells[5].Value) + qtyToAdd;
        }
    }
    private int FindRowIndexByID(string id)
    {
        for (int i = 0; i < dgvPOSproduct.Rows.Count; i++)
        {
            if (dgvPOSproduct.Rows[i].Cells[0].Value == id)
            {
                return i;
            }
        }
        return -1;               
    } 
