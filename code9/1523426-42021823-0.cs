    HtmlElementCollection Bclick = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement Btn in Bclick)
            {
                string name = Btn.Name;
                if (name == "submit")
                    Btn.InvokeMember("click");
            }
