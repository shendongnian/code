    private void button3_Click(object sender, EventArgs e)  
            {  
                 this.dataGridView1.ClearSelection();  
                      foreach (DataGridViewRow row in dataGridView1.Rows)  
                         {  
                           if (row.IsNewRow || (this.OwnedForms!=null && this.OwnedForms.Count>=15) { return; }  
                           foreach (DataGridViewCell cell in row.Cells)  
                           {  
                               // Validating cell value  
                               var regexItem = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9 ]$");  
                               if (cell.Value == null || !regexItem.IsMatch(cell.Value.ToString()))  
                               {  
                                   cell.Style.BackColor = Color.Red;  
                               }  
    
                           }  
                        }  
                   this.Hide();  
                   resultVV f2 = new resultVV();  
    f2.Owner = this;
                   f2.Show();  
           }  
