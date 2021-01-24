	//list to hold intem indexes
	List<int> itemIndexes = new List<int>(); 
	foreach (ListViewItem item in listView1.Items)
	{
		foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
		{
			var index = item.Index;
			if (subItem.Text.ToLower().StartsWith(textBox1.Text.ToLower()))
			{
				//your code (which doesnt compile since you didn't paste whole code)
				//to test this, I had to remove following 4 lines.
				int.TryParse(listView1.Items[index].SubItems[4].Text, out val);
				store[pos] = val;
				pos++;
				count++;
			}
			else
			{
				itemIndexes.Add(index);
			}
		}
	}
	//lastly, sort indexes descending (for example: 10, 5,4,1)
	//because if you remove item 1, whole list will shorten and 
	//you'll get index out of bounds error (in last step when 
	//trying to remove item with 10 but last index is 7)...
	itemIndexes.Reverse();
	//... and remove them from listview
	foreach (int index in itemIndexes)
	{
		listView1.Items.RemoveAt(index);
	}
