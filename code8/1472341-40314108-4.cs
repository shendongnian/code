    //Small Text files
    var originallist = File.ReadAllLines(filepath).ToList();
    //Large Text files
    var originallist = new List<string>();
    string line = "";
    var sr = new StreamReader(filename);
    while ((line = sr.ReadLine()) != null)
    {
       originallist.Add(line);
    }
    sr.close();
    var list = new List<test>();
    //var distinct = originallist.Distinct().ToList();
    var duplicates = (originallist.GroupBy(s => s).SelectMany(grp => grp.Skip(1))).ToList(); //Filtering out the Duplicates.
    for (int i = 0; i < originallist.Count; i++)
    {
       var itm = originallist[i];
       if (duplicates.Contains(itm))
          list.Add(new test() { index = i, value = itm }); //Adding the duplicate items to a separate list with the index and value. 
    }
    for (int i = 0; i < list.Count; i++)
    {
       var itm = list[i];
       var itm2 = list.Where(x => x.value == itm.value).Select(x => x).ToList();
       if (itm2.Count > 1)
       {
          itm2.RemoveAt(0); //Removing the first occurrence, as that is not to be removed. 
          try
          {
             foreach(var itm3 in itm2)
             {
               originallist[itm3.index] = null; //Replacing the duplicated item with null.
               originallist[itm3.index + 1] = null; //Replacing the second line with null.
             }             
           }
           catch { }
        }
     }
     originallist.RemoveAll(x => x == null); // then remove all nulls
    public class test
    {
        public int index { get; set; }
        public string value { get; set; }
        public override string ToString()
        {
            return index.ToString() + " | " + value;
        }
    }
