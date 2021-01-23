            void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e){ 
         try {
               int price, quantity, total;         
             quantity= int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
             cena = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString());
             total = quantity * price ;
            dataGridView1.Rows[e.RowIndex].Cells["Total"].Value = total;
        } catch(ArgumentNullException)  { ... }
    } 
