    bool result = dataGridView1.Rows.Cast<DataGridRow>().Any(row => 
        Convert.ToDateTime(row.Cells[3].Value) >= DateTime.Parse("0:05:00") &&
        Convert.ToDateTime(row.Cells[3].Value) <= DateTime.Parse("0:19:59") &&
        row.Cells[1].Value.ToString().Trim() == "4 - Needs to be solved");
    if (result)
    {
        // Of course you should stop the timer to avoid another call to this
        // with the same result and with another MessageBox.
        timer1.Enabled = false;
        MessageBox.Show("You have 1 task to be solved!");
    }
