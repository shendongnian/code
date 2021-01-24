    //StringBuilder resultText = new StringBuilder(@"This is a <ss type="""">(example)</ss> string which <ss type="""">(contains)</ss> tagged contents.");
    //You have to use """" instead on "" in this line 
    StringBuilder resultText = new StringBuilder(@"This is a <ss type="""">(example)</ss> string which <ss type="""">(contains)</ss> tagged contents.");
    string overallPattern = @"<ss\stype=""([a-zA-Z]*)"">(.*?)</ss>";
    List<string> matchList = new List<string>();
    List<string> contentList = new List<string>();
    StringBuilder sb;
    Regex overallRegex = new Regex(overallPattern, RegexOptions.None);
    string resultContent = resultText.ToString();
    foreach (Match match in overallRegex.Matches(resultContent))
    {
        string matchResult = match.ToString();
        matchList.Add(matchResult);
        string content = matchResult.Split('(', ')')[1];
        contentList.Add(content);
    }
    for (int j = 0; j < matchList.Count; j++)
    {
        //Dynamic Regex based on tag content for replace
        overallPattern = @"<ss\stype=""([a-zA-Z]*)"">\("+ contentList[j] + "\\)</ss>";
        sb = new StringBuilder();
        sb.Append(matchList[j].Insert(10, string.Format(contentList[j])));
        resultContent = Regex.Replace(resultContent, overallPattern, sb.ToString());
        resultText = new StringBuilder();
        resultText.Append(resultContent);
    }
