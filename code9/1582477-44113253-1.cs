    if (theDialog.ShowDialog() == DialogResult.OK)
    {
    	var lines = File.ReadAllLines(theDialog.FileName);
    	foreach (string line in lines)
    	{
    	    string[] fileItems = line.Split('|');
    		ListViewItem lv = new ListViewItem();
    		lv.Text = fileItems[0].ToString();
    		lv.SubItems.Add(fileItems[1].ToString());
    		lv.SubItems.Add(fileItems[2].ToString());
    		basket.Items.Add(lv);
    	}
    }
