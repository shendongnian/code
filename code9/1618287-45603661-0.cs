    string query = queryHtml.DocumentNode.SelectNodes(
                   @"//div[@class='queryBody']
                   /span")[0].InnerHtml;
    string pattern = @"([\w.]+)@([\w.]+)\.([a-z]+)";
    Match match = Regex.Match(par, pattern);
    string email = "";
    if (match.Success)
    {
        email = match.Value;
    }
