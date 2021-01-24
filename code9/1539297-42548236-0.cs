    string[] allLines = File.ReadAllLines(@"E:\stackfiletext.txt");
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    for (int i = 0; i < allLines.Length; i++)
    {
      if (allLines[i] != null)
      {
        if (allLines[i].Contains(":") & allLines[i].Count(x => x == ':') > 1)
        {
          int pFrom = allLines[i].IndexOf(":") + ":".Length;
          int pTo = allLines[i].LastIndexOf(":");
          string result = allLines[i].Substring(pFrom, pTo - pFrom);
          string textResult = "";
          int innerCounter = 0; ;
          for (int j = i; j < allLines.Length; j++)
          {
             innerCounter++;
             string newLine = allLines[j];
             if (!(newLine.Contains(":") & newLine.Count(x => x == ':') > 1))
             {
                textResult += newLine;
                i++;
             }
             else if (innerCounter == 0)
             {
                break;
             }
             else
             {
                i++;
             }
         }
         dictionary.Add(":" + result + ":", textResult);
       }
      }
    }
