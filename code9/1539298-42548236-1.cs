    string[] allLines = File.ReadAllLines(@"E:\stackfiletext.txt");
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    int pFrom = 0;
    int pTo = 0;
    string result = "";
    string keyValue = "";
    bool firstIterataion = true;
    for (int i = 0; i < allLines.Length; i++)
    {
      if (allLines[i] != null)
      {
        string line = allLines[i];
        if (allLines[i].Contains(":") & allLines[i].Count(x => x == ':') > 1)
        {
           if (!firstIterataion)
           {
              dictionary.Add(":" + result + ":", keyValue);
              keyValue = string.Empty;
           }
           pFrom = allLines[i].IndexOf(":") + ":".Length;
           pTo = allLines[i].LastIndexOf(":");
           result = allLines[i].Substring(pFrom, pTo - pFrom);
        }
        else if (!(allLines[i].Contains(":") & allLines[i].Count(x => x == ':') > 1))
        {
           keyValue += line;
        }
        firstIterataion = false;
       }
     }
    if (!firstIterataion)
    {
       dictionary.Add(":" + result + ":", keyValue);
       keyValue = string.Empty;
    }
