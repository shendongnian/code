    var inputs = webBrowser1.Document.GetElementsByTagName("input");
    foreach (HtmlElement link in links)
    {
        if (inputs.GetAttribute("className") == "id txt_b")
        {
            inputs.SetAttribute("value", idText.Text);
        }
    }
