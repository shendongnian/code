    private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
    {
    	if (e.KeyChar == (char)Keys.Enter)
    	{
    		dateTimePicker2.Focus();
    	}
    }
    
    private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
    {
    	if (e.KeyChar == (char)Keys.Enter)
    	{
    		dateTimePicker1.Focus();
    	}
    }
