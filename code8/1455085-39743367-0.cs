    private void AddButton_Click(object sender, EventArgs e)
    {
        dataGridView1.Rows.Add(SNoTextBox.Text, PriceTextBox.Text, QtyTextBox.Text);
        foreach(DataGridViewRow row in dataGridView1.Rows)
        {
            row.Cells[dataGridView1.Columns["Amount"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["Price"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Qty"].Index].Value));
        }
    }
    List<decimal> list = dataGridView1.Rows
             .OfType<DataGridViewRow>()
             .Select(r => Convert.ToDecimal(r.Cells["Amount"].Value.ToString()))
             .ToList();
    GrandTotalTextBox.Text = list.Sum().ToString();
