    var query = queryHtml.DocumentNode.SelectNodes(
               @"//div[@class='queryBody']
               /span");
    var pattern = @"\S+@\S+\.\S+";
    var email = "";
    if (query != null)
    {
        var emailNode = query.Descendants().Where(m => Regex.IsMatch(m.InnerText, pattern)).FirstOrDefault();
        if (emailNode != null)
        {
            email = Regex.Match(emailNode.InnerText, pattern).Value;
        }
    }
