    private void PathExist()
    {
    	if (Directory.Exists(folderBrowserDialog.SelectedPath + @"\"))
    	{
    		lblExist.Visible = false;
    		Properties.Settings.Default.FirstTime = false;
    		// Create a new instance of the Form2 class
    		MainFrm MainForm = new MainFrm();
    		MainForm.Show();
    		Hide(); //This is where Visual Studio is telling me that a "}" is expected
    	}        
        else 
        {
    		lblExist.Visible = true;
    		lblExist.Text = "Folder doesn't exist";
    		lblExist.ForeColor = Color.Red;
    
    	}
    }
