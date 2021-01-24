        foreach (HtmlElement elem in browser.Document.GetElementsByTag("a"))
        {
            if (elem.InnerText == "hey")
            {
                elem.InnerText = "blabla";
                break;
            }
        }
