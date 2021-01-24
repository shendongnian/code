    void Main()
    {
    	Save();
    }
    
    private string _filePath = "";
    void Save()
    {
    	var overwrite = false;
    
    	if (!string.IsNullOrEmpty(_filePath))
    	{
    		var res =
    		MessageBox.Show("Would you like to overwrite your last saved file?", "Overwrite?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
    		MessageBoxOptions.DefaultDesktopOnly, false);
    
    		if (res == DialogResult.Cancel) return;
    		if (res == DialogResult.No) overwrite = false;
    		if (res == DialogResult.Yes) overwrite = true;
    	}
    
    	if (!overwrite)
    	{
    		var sfd = new SaveFileDialog();
    		sfd.Filter = "Rich Text File|*.rtf";
    		var res = sfd.ShowDialog();
    		if (res != DialogResult.OK) return;
    		_filePath = sfd.FileName;
    	}
    	
    	// do the richTextBox.SaveFile(_filePath) here.
    
    }
