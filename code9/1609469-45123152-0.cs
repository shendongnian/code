    public ArrayList HRefs(string incomingHtml)
    {
      ArrayList arrayList = new ArrayList();
      string pattern = "href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))";
      for (Match match = Regex.Match(incomingHtml, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled); match.Success; match = match.NextMatch())
      {
        string str = match.Groups[1].Value;
        arrayList.Add((object) str);
      }
      return arrayList;
    }
