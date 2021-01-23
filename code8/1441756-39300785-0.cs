    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                int price, quantity, total;         
    
                 quantity= int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
    
    		if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString(), out price))
    		{
    			 price = 0;
    		}
    
                 total = quantity * price ;
    
                dataGridView1.Rows[e.RowIndex].Cells["Total"].Value = total;
            }
