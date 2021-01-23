    var originallist = File.ReadAllLines(filepath).ToList();
    var list = new List<string>();
    var duplicates = originallist.GroupBy(s => s).SelectMany(grp => grp.Skip(1));
    
    for(int i = 0; i < originallist.Count; i++)
    {
       var itm = originallist[i];
       if (dublicates.Contains(itm))
       {
          originallist.Remove(i);
          originallist.Remove(i);
          dublicates.Remove(itm);
       }
    }
