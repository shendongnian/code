    string[] lines = File.ReadAllLines("path");
    //                         ID, time
    var dict = new Dictionary<int, int>();
    // Processing each line of the file content
    foreach (var line in lines)
    {
        string[] splitted = line.Split('|');
        int time = Convert.ToInt32(splitted[0]);
        int ID = Convert.ToInt32(splitted[1]);
        // Key = ID, Value = Time
        dict.Add(ID, time);
    }
    var orderedListByID = dict.OrderBy(x => x.Key).ToList();
    var orderedListByTime = dict.OrderBy(x => x.Value).ToList();
