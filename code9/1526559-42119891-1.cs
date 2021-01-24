    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
    	if (MessageBox.Show("Are you sure you want to exit ?",
    				"Are you sure you want to exit ?",
    				MessageBoxButtons.YesNo,
    				MessageBoxIcon.Information) == DialogResult.No)
    	{
    	  e.Cancel = true; // cancels the close action
    	}
    	else
    	  Application.Exit(); // closes the app, this might not be necessary. Just proceeding with the form close is enough UNLESS this is not the main application form
    
    }
