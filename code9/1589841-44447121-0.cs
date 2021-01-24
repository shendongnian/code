    private void buttonSave_Click(object sender, EventArgs e)
    {
    	try
    	{
    		string path;
    		SaveFileDialog sfd = new SaveFileDialog();
    		sfd.Filter = "Png Image (.png)|*.png";
    
    		if (sfd.ShowDialog() == DialogResult.OK)
    		{
    			path = sfd.FileName;
    
    			if (!string.IsNullOrEmpty(path))
    			{
    				chart1.SaveImage(path, ChartImageFormat.Png);
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
    }
