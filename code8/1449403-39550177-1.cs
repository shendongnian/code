     foreach (DataGridViewRow item in dataGridView1.Rows.OfType<DataGridViewRow>().Where(c => c.Cells[buttonCol.Index].Value != null && c.Cells[buttonCol.Index].Value.ToString() == "ACCEPTED"))
     {
         //you can replace the button with a textbox cell that contains the rejected value
         item.Cells[buttonCol.Index] = new DataGridViewTextBoxCell { Value = "REJECTED" }; 
         item.Cells[buttonCol.Index].ReadOnly = true;
         //note that you have to make a new button cell and replace the rejected ones if the status is updated later on to be able to use the button.
     }
