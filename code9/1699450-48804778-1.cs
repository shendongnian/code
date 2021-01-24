    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            e.Handled = true; // <- do not pass the event to DataGridView
     
            MessageBox.Show("Hello");
        }
    }
