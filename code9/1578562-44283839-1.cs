    // not setting the datagridview cell to readonly
    foreach (DataGridViewRow row in dgvMailPreferences.Rows) {
        foreach (DataGridViewCell cell in row.Cells) {
            if (cell is DataGridViewCheckBoxCell) {
                DataGridViewCheckBoxCell checkBox = cell as DataGridViewCheckBoxCell;
                if(checkBox.Value == false) {
                    check.ReadOnly = true;
                }
            }
        }
    }
