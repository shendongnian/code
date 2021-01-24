    private void Form1_Load(object sender, EventArgs e)
    {
        RefreshList();
        combobox.SelectedIndexChanged += 
			new System.EventHandler(ComboBox1_SelectedIndexChanged);
    }
    private void RefreshList() 
    {
        DirectoryInfo dinfo = new DirectoryInfo(combobox.SelectedItem);
        DirectoryInfo[] folders = dinfo.GetDirectories();
        FileInfo[] Files = dinfo.GetFiles();
    
        cbobox.DataSource = folders;
    
        foreach(FileInfo file in Files)
        {
            lstbox.Items.Add(file.Name);
        }
    }
    private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		RefreshList();
	}
