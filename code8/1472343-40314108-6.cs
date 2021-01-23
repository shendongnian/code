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
    // Filter and sort the list and returns the duplicated indexes..
    var duplicateIndexes = originallist.Select((name, index) => new { name, index }).GroupBy(g => g.name).Where(g => g.Count() > 1).SelectMany(g => g.Skip(1), (g, item) => item.index).ToList();
    foreach (var itm in duplicateIndexes)
    {
       originallist[itm] = null; //Replacing the duplicated item with null.
       originallist[itm + 1] = null; //Replacing the second line with null.
    }
    originallist.RemoveAll(x => x == null); // then remove all nulls
