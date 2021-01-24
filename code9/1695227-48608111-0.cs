    private void grid_EditingControlShowing(object sender, 
        DataGridViewEditingControlShowingEventArgs e)
    {
        if ( grid.CurrentCell.ColumnIndex == dgvr.Columns["field2name"].Index )
        {
             // Get Combobox
             ComboBox combo = e.Control as ComboBox;
             // Get Other Column's Value
             string wsId = grid.Rows[grid.CurrentCell.RowIndex].Cells["filed1id"].Value.ToString();
             // Get Filtered Data Based Off Of Other Column's Value
             DataTable filteredData = (combo.DataSource as DataTable).Select("thefieldname = " + wsId).CopyToDataTable();
             DataView dv = filteredData.DefaultView;
             dv.Sort = "field2name";
             
             // Rebind
             combo.DataSource = null;
             combo.DisplayMember = "field2name";
             combo.ValueMember = "field2id";
             combo.DataSource = dv.ToTable();
        }
    }
