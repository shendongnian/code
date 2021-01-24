    private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) {
            dateTimePicker2.Focus();
        }
    }
    private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) {
            dateTimePicker1.Focus();
        }
    }
