	private void textBox_KeyPress(object sender, KeyPressEventArgs e)
	{
        TextBox textBox = sender as TextBox;
		
		// Only allow 0-9, ., -
		if (!char.IsControl(e.KeyChar) && 
            !char.IsDigit(e.KeyChar) &&
            e.KeyChar != '-' &&
            e.KeyChar != '.')
		{
			e.Handled = true;
		}
 
        // Avoid double decimals
        if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
		{
			e.Handled = true;
		}
        // Ensure hyphen is at the beginning
        if (e.KeyChar == '-' && 
            (textBox.Text.Contains('-') || 
            textBox.SelectionStart != 0))
        {
            e.Handled = true;
        }
	}
