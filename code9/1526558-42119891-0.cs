    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
    	if (MessageBox.Show("Are you sure you want to exit ?",
    				"Are you sure you want to exit ?",
    				MessageBoxButtons.YesNo,
    				MessageBoxIcon.Information) == DialogResult.No)
    	{
    	  e.Cancel = true;
    	}
    	else
    	  Application.Exit();
    
    }
