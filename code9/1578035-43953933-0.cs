    @using System.Text.RegularExpressions;
     public string StripHtml(string inputHTML)
     {
        if (inputHTML == null) {
            return string.Empty;
        }
        string noHTML = Regex.Replace(inputHTML, @"<[^>]+>|&nbsp;", "").Trim();
        string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");
        return noHTMLNormalised;
    }
