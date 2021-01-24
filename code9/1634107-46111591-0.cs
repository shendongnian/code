     private void DeleteSelectedRows_Click(object sender, EventArgs e)
     {
         foreach (DataGridViewRow row in DataGrid.SelectedRows)
         {
             Datagrid.Rows.RemoveAt(row.Index);
         }
     }
