    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
    	if (e.KeyCode != Keys.ShiftKey)
    	{
    		if (e.Modifiers.ToString() == "Shift")
    		{
    			var c = User32Interop.ToAscii(e.KeyCode, Keys.ShiftKey);
    			MessageBox.Show(c.ToString());
    		}
    	}
    }
