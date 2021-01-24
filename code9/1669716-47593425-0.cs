    using System.Linq;
    ...
    
    //cast ListViewItemCollection as List<ListViewItem> for easier manipulation
    var items = listView1.Items.Cast<ListViewItem>();
    //first, get all items that have text matching with textBox text
    List<int> itemIndexes = 
    	items
    		.Where(item => item.SubItems[4].Text.ToLower().StartsWith(textBox1.Text.ToLower()))
    		.Select(item => item.Index).ToList();
    int val;
    //now, with all those indexes do your stuff
    itemIndexes.ForEach(index =>
    	{
    		int.TryParse(listView1.Items[index].SubItems[4].Text, out val);
    		store[pos] = val;
    		pos++;
    		count++;
    	});
    
    //lastly, sort indexes descending (for example: 10, 5,4,1) and remove them from listview
    itemIndexes
    	.OrderByDescending(i=>i)
    	.ToList()
    	.ForEach(index => listView1.Items.RemoveAt(index));
