    string[] aLines = File.ReadAllLines("test.txt");
    List<string> lMeta = new List<string>();
    foreach (string sLine in aLines)
    {
        string[] aItems = sLine.Split('¬');
        lMeta.Add("\"" + string.Join("\",\"", aItems) + "\"");
    }
    File.WriteAllLines("meta.csv", lMeta);
