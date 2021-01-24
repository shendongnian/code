    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
    	if (e.Control && e.KeyCode == Keys.A) // Select All
    	{
    		((TextBox)sender).SelectAll();
    		e.SuppressKeyPress = true;
    		e.Handled = true;
    	}
    }
