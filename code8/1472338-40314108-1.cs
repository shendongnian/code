    var originallist = File.ReadAllLines(filepath).ToList();   
    var list = new List<test>();
    var distinct = originallist.Distinct().ToList();
    var duplicates = (originallist.GroupBy(s => s).SelectMany(grp => grp.Skip(1))).ToList();
    for (int i = 0; i < originallist.Count; i++)
    {
       var itm = originallist[i];
       if (duplicates.Contains(itm))
          list.Add(new test() { index = i, value = itm });
    }
    public class test
    {
        public int index { get; set; }
        public string value { get; set; }
        public override string ToString()
        {
            return index.ToString() + " | " + value;
        }
    }
