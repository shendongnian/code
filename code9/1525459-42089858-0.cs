            HtmlElementCollection links = MyBrowser.Document.GetElementsByTagName("A");
            foreach (HtmlElement link in links)
            {
                if (link.InnerText!=null && link.InnerText.Equals("Export to"))
                    link.InvokeMember("Click");
            }
