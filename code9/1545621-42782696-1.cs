    bool found = false;
    foreach (DataGridViewRow dgvr in dgvInventory.Rows)
    {
        if (tbItem.Text == dgvr.Cells[0].Value.ToString())
        {
            found = true;
            break;
        }
    }
    if (found)
    {
           btnAdd.Enabled = false;
           lblAdd.Text = "Item name cannot be the same";
    }
    else
    {
           btnAdd.Enabled = true;
           lblAdd.Text = "Accepted";
    }
