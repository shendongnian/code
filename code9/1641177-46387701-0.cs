        private void dgvOrder_SelectionChanged(object sender, EventArgs e)
             {
                 if (dgvOrder.SelectedCells.Count > 0)
                 {
                     int selectedrowindex = dgvOrder.SelectedCells[0].RowIndex;
        
                     DataGridViewRow selectedRow = dgvOrder.Rows[selectedrowindex];  
        
                      string orderlineFilter = Convert.ToString(selectedRow.Cells["columnname"].Value);           
        
                      
                     (dgvOrderLine.DataSource as DataTable).DefaultView.RowFilter = string.Format("Field = '{0}'", orderlineFilter);
                 }
             }
