    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                  if(dataGridView1.Columns[e.ColumnIndex].Name == "C")
                  {
                      if(e.Value != null)
                      {
                          String StringValue =(String)e.Value;
                          if (StringValue.IndexOf("C1") > -1)
                          {
    
                              dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                          }
                      }
    
                  }
    
            }
