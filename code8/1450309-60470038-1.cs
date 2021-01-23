    webBrowser1.Navigate("the url or your page");
    webBrowser1.DocumentCompleted += (obj, args) =>
    {
        var element = webBrowser1.Document.GetElementsByTagName("input")
            .Cast<HtmlElement>()
            .Where(x => x.GetAttribute("value") == "2" &&
                        x.GetAttribute("name") == "chosen")
            .FirstOrDefault();
        element.InvokeMember("click");
        var submit = webBrowser1.Document.GetElementsByTagName("input")
            .Cast<HtmlElement>()
            .Where(x => x.GetAttribute("type") == "submit" &&
                        x.GetAttribute("value")=="Next")
            .FirstOrDefault();
            submit.InvokeMember("click");
    };
