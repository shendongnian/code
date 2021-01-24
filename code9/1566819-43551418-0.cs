         private void GrdVw_Reception_CellValueChanged(object sender, DataGridViewCellEventArgs e)
         {
             if(e.ColumnIndex == TheColumnIndexOfTheCheckBoxColumn){
                 MessageBox.Show("CheckBox changed in the row " + e.RowIndex);
         
             }
         }
