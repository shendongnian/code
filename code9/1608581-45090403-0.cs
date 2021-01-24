    private void ClickButtonByInnerText(string innerText)
    {
    	foreach (HtmlElement elem in webBrowser1.Document.GetElementsByTagName("button"))
    	{
    		if (elem.InnerText == innerText)
    		{
    			elem.InvokeMember("Click");
    		}
    	}
    }
