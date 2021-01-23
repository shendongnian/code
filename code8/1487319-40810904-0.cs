     Dictionary<string, int> itemCounts = 
     pChain.Select(list => list.Aggregate((i, j) => j + '/' + i))
    .GroupBy(item => item).OrderByDescending(x => x.Key)
    .ToDictionary(g => g.Key.ToString(), g => g.Count());
    
     foreach (var v in itemCounts)
     {
         ListViewItem lv = listView2.Items.Add(v.Key.ToString());
    
         lv.SubItems.Add(v.Value + "");
     }
