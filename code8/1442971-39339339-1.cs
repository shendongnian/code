    List<string> list1 = listView1.Items.Cast<ListViewItem>()
                            .Select(item => item.Text)
                            .ToList();
    List<string> list2 = listView2.Items.Cast<ListViewItem>()
                            .Select(item => item.Text)
                            .ToList();
    var commonUsers = list1.Select(a => a.Text).Intersect(list2.Select(b => b.Text)); // or use .Except to get the opposite
