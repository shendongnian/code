    var items = listView1.Items.OfType<ListViewItem>();
    var query = items.SelectMany(item => 
                   Enumerable.Range(1, Convert.ToInt32(item.SubItems[1].Text))
                             .Select(i => new { Item = item, Index = i});
    foreach(var element in query)
    {
        Console.WriteLine("Book: {0}, i: {1}", element.Item.Text, element.Index);
    }
