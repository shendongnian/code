    public class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
    /////
    var list = new List<(Item Col1, int Rank)>();
    
    var nameGroup = items.GroupBy(i => i.Name);
    var sorted = nameGroup.OrderBy(i => i.Key);
    
    foreach (var group in sorted)
    {
        int ranking = 1;
        foreach (var item in group.OrderByDescending(i => i.Value))
        {
            list.Add((Col1: item, Rank: ranking++));
        }
    }
