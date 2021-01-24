     private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
     {
          Type type = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType();
    
          if (type.Name == "DataGridViewCheckBoxCell")
          {
    
          }
     }
