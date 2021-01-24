    foreach (var article in articles)
    {
        string articleTemplateValue = _TemplateArticleMarkup;
        MatchCollection mc = Regex.Matches(articleTemplateValue, @"\[ARTICLEIMAGE\:(\d+)\:(\d+)\]");
        if (mc.Count > 0)
        {
            string toReplace = mc[0].Value;
            string xx = mc[0].Groups[1].Value;
            string yy = mc[0].Groups[2].Value;
            articleTemplateValue = articleTemplateValue.Replace(toReplace, "<img src=\"" + article.ArticleImageFolder + "/" + article.ArticleImage + "\" title=\"" + article.ArticleTitle + "\" width=\"" + xx + "\" height=\"" + yy + "\"/>");
         }
    }
