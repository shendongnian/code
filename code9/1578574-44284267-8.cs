    // Loop through all the rows of your grid
    foreach (DataGridViewRow row in this.dgvMailPreferences.Rows)
    {
        // Loop through all the cells of the row
        foreach (DataGridViewCell cell in row.Cells)
        {
            // Check if the cell type is CheckBoxCell
            // If not, check the next cell
            if (!(cell is DataGridViewCheckBoxCell)) continue;
    
            // Set the specific cell to read only, if the cell is not checked
            cell.ReadOnly = !Convert.ToBoolean(cell.Value);
        }
    }
