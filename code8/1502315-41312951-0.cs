        private void Get_Data()
        {
            foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("div"))
            {
                if (el.GetAttribute("className") == "_cgc")
                {
                    string[] splitSpan = el.InnerText.Split(new[] { "<span>", "</span>" }, StringSplitOptions.None);
                    description.Text = splitSpan[1];
                }
            }
        }
