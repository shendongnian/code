    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
           if (dataGridView1.Rows[i].Cells[0].Value.ToString() == null)
           {
                textbox.Text = "null";
                break;
           } 
     }
    if(textbox.Text != "null")
    { 
         MessageBox.Show("No null"); 
    }
