    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
       if ((e.ColumnIndex == 0) & (e.RowIndex >= 0))
       {
          string sFileName = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
          using (Bitmap _bitmap = new Bitmap(sFileName, true))
          {
             this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = new Bitmap(_bitmap);
          }
       }
    
    }
