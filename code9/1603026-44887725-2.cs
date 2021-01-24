    public class Entry
    {
        public int Value { get; set; }
        public double Percent { get; set; }
    }
    public class Item
    {
       public Entry[] Entries { get; set; }
    }
    var item = new Item
    {
        Entries = jsonItem.Entries.Select(x => new Entry { Value = (int) x[0], Percent = x[1]}).ToArray()
    };
