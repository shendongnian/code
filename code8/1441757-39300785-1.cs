        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
                {
                    int price, quantity, total;         
        
       if(dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value != null)
        {
    		if(!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out quantity))
        		{
        			 quantity= 0;
        		}
        }else
        {
        	quantity= 0;
        }    
            		             price = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString());
            
                         total = quantity * price ;
            
                        dataGridView1.Rows[e.RowIndex].Cells["Total"].Value = total;
                    }
