    RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
    Regex regx = new Regex("<body>(?<bodyContents>.*?)</body>", options);
    Match matchResult = regx.Match(html);
    List<string> resultList = new List<string>();
    while (matchResult.Success)
    {
           var d = matchResult.Groups["bodyContents"].Value;
           resultList.Add(d.Trim());          
           matchResult = matchResult.NextMatch();
    }
