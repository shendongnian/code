    foreach (var line in lines)
    {
		ListViewItem lvItem = new ListViewItem();
	
		var newLine = line.Remove(0.8);
		
        if (line.StartsWith("package:/system/app"))
        {
            ApkList.Items.Add(newLine);
        }
        if (line.StartsWith("package:/system/priv-app"))
        {
            lvItem.SubItems.Add(newLine);
        }
        if (line.StartsWith("package:/data/app"))
        {
            lvItem.SubItems.Add(newLine);
        }
        ApkList.Items.Add(lvItem);
    }
