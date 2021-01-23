    private void AddButton_Click(object sender, EventArgs e)
    {
        decimal amount =0;
        dataGridView1.Rows.Add(SNoTextBox.Text, PriceTextBox.Text, QtyTextBox.Text);
        
         foreach(DataGridViewRow row in dataGridView1.Rows)
         {
               row.Cells[dataGridView1.Columns["Amount"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["Price"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Qty"].Index].Value));
        
               amount += Convert.ToDecimal(row.Cells[dataGridView1.Columns["Amount"].Index].Value);
          }
        GrandTotalTextBox.Text = amount.ToString();
    }
