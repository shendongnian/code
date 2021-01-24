	var MaxNum = Math.Min(SmallWords.Count, LargeWords.Count);
				//    ^---  Changed Max to Min
					
	for (var index = 0; index < MaxNum; index++)
	{
	     ListViewItem item = new ListViewItem(SmallWords[index]);
	     item.SubItems.Add(LargeWords[index]);
	     listView1.Items.Add(item);
	}
