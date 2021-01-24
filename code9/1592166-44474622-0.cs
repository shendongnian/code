    string htmlContent = GetHtmlContentFromPage("SomePasteBinURL");
    //Possibly your new WebClient().DownloadString("SomePasteBinURL");
    Match match = rgx.Match(htmlContent);
    string rawContent = "ERROR: No Raw content found!";
    if (match.Groups.Count > 0)
    {
        rawContent = match.Groups[1].Value;
    }
    int numberOfLines = rawContent.Split('\n').Length.ToString();
