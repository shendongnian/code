     private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
     {
         if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index > -1)
         {
             string value1 = dataGridView1.CurrentRow.Cells[0].Value != null ? dataGridView1.CurrentRow.Cells[0].Value.ToString() : "";
             textBox1.Text = value1; 
             string value2 = dataGridView1.CurrentRow.Cells[1].Value != null ?  dataGridView1.CurrentRow.Cells[1].Value.ToString() : "";
             textBox2.Text = value2;
             .
             .
             .
         }
     }
   
