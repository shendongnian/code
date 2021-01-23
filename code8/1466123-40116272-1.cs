    using (StreamWriter sw = File.CreateText(DirectoryPath))
    {
    	foreach (ListViewItem item in listView1.Items)
    	{
    		
    		string strText = "";
    		
            //I'm not sure why you start at 1 and not 0, anyway:
    		for (int i = 1; i < item.SubItems.Count; i++)
    		{
    			strText+= " " + item.SubItems[i].Text;
    		}
    		
    		sw.WriteLine(strText);
    	}
     }
