    private void button1_Click(object sender, EventArgs e)
    {
       if (selectedRow.HasValue)
       {
         DataGridViewRow dgRow = dataGridView1.Rows[selectedRow.Value];
    
        //move your data to cart
        // reset variable
        selectedRow = null;
       }
       else
       {
       //show a message that none is seleted;
       return;
       }
    
    }
