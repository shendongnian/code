    HtmlElement submit = FindSubmitElement(webBrowser1.Document);
    submit?.InvokeMember("submit");
    public HtmlElement FindSubmitElement(HtmlDocument document) 
    {
        HtmlElementCollection elems = document.GetElementsByTagName("div"); // since your tag is div
        // this will return collection, even in case there is just one div, find the first one, having an attribute 'type' with value 'submit'
        foreach (HtmlElement elem in elems)
        {
            string type = elem.GetAttribute("type");
            if (!string.IsNullOrEmpty(type) && type == "submit") 
            {
                return elem; // if div tag with attribute type is found exit and return that html element
            }
        }
        return null; // if no div tags found with an attribute 'type' return null
    }
