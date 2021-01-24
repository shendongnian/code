    // not setting the datagridview cell to readonly
    foreach (DataGridViewRow row in dgvMailPreferences.Rows) {
        foreach (DataGridViewCell cell in row.Cells) {
            if (cell.GetType() == typeof(DataGridViewCheckBoxCell)) {
                if((DataGridViewCheckBoxCell)cell).Value == false) {
                    ((DataGridViewCheckBoxCell)cell).ReadOnly = true;
                }
            }
        }
    }
