    private void expenses_KeyUp(object sender, KeyEventArgs e)
    {
        if (expenses.Text != string.Empty)
        {
            decimal Pprice = Convert.ToDecimal(buyTotal.Text);
            decimal expens = Convert.ToDecimal(expenses.Text);
            decimal final = Pprice + expens;
            buyTotal.Text = final.ToString();
        }
        if (e.KeyCode == Keys.Back)
        {
            buyTotal.Text = (from DataGridViewRow row in dataGridView1.Rows where row.Cells[6].FormattedValue.ToString() != string.Empty select Convert.ToDecimal(row.Cells[6].FormattedValue)).Sum().ToString();
        }
    }
