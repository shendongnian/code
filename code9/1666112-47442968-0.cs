    public void SetFonts()
    {
        string strHtml = "<span style=\"font-size: 10px; \">Hi This is just a section of html text.</span><span style=\"font-family: 'Verdana'; font-size: 10px; \">Please help</span><span>me add style attributes to span tags.Thank You</span>";
        HtmlDocument document = new HtmlDocument();
        document.LoadHtml(strHtml);
        SetFonts(document.DocumentNode);
        document.Save(Console.Out);
    }
    public void SetFonts(HtmlNode node)
    {
        foreach (var item in node.Elements("span"))
        {
            var style = item.GetAttributeValue("style", null);
            if (style != null)
            {
                if (!style.Contains("font-family"))
                {
                    var newValue = style + "font-family: 'Verdana';";
                    item.SetAttributeValue("style", newValue);
                }
            }
            SetFonts(item);
        }            
    }
