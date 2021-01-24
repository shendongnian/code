         private void GrdVw_Reception_CellClick(object sender, DataGridViewCellEventArgs e)
         {
             if(e.ColumnIndex == TheColumnIndexOfTheCheckBoxColumn){
                 bool currentValue = !(bool)GrdVw_Reception.Rows[e.RowIndex].Cells[0].Value;
                 GrdVw_Reception.Rows[e.RowIndex].Cells[0].Value = currentValue;
                GrdVw_Reception.EndEdit();
                MessageBox.Show("Value " + currentValue.ToString());
         
             }
         }
