    private void F0100_FormClosing(object sender, FormClosingEventArgs e)
    {
    	DialogResult result;
    	result = MessageBox.Show("Are you sure you want to exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    	if (result != DialogResult.Yes)
    	{
    		e.Cancel = true;
    	}
    }
