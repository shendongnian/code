    // not setting the datagridview cell to readonly
    foreach (DataGridViewRow row in dgvMailPreferences.Rows) {
        foreach (DataGridViewCell cell in row.Cells) {
            if (cell is DataGridViewCheckBoxCell) {
                DataGridViewCheckBoxCell checkBox = cell as DataGridViewCheckBoxCell;
                //What is the initial  value in the checkbox
                bool isChecked = checkBox.Value as bool;
                //set to readonly if not checked
                checkBox.ReadOnly = !isChecked;                 
            }
        }
    }
