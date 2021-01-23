    webBrowser1.Navigate("the url or your page");
    webBrowser1.DocumentCompleted += (obj, args) =>
    {
        var radio = webBrowser1.Document.GetElementsByTagName("input")
            .GetElementsByName("chosen")
            .Cast<HtmlElement>()
            .Where(x => x.GetAttribute("value") == "3")
            .FirstOrDefault();
        radio?.InvokeMember("click");
        var submit = webBrowser1.Document.GetElementsByTagName("input")
            .Cast<HtmlElement>()
            .Where(x => x.GetAttribute("type") == "submit")
            .FirstOrDefault();
        submit?.InvokeMember("click");
    };
