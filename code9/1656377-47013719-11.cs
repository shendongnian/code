    foreach (HtmlElement elem in browser.Document.GetElementsByTag("div"))
    {
        if (elem.GetAttribute("name") == "something")
        {
            elem.Destroy;
            break;
        }
        if (elem.GetAttribute("name") == "notme")
        {
            elem.Destroy;
            break;
        }
        if (elem.GetAttribute("name") == "notyou")
        {
            elem.Destroy;
            break;
        }
        if (elem.GetAttribute("name") == "notthat")
        {
            elem.Destroy;
            break;
        }
        if (elem.GetAttribute("name") == "theone")
        {
            elem.Destroy;
            break;
        }
    }
