            private string CallSanitizers(string str)
        {
            if (str != HttpUtility.HtmlEncode(str))
            {
                doc.LoadHtml(str);
                str = Sanitizers();
                return doc.DocumentNode.WriteTo().Trim();
            }
            else
            {
                return str;
            }
        }
        private string Sanitizers()
        {
            doc.DocumentNode.Descendants().Where(l => l.Name == "script" || l.Name == "style").ToList().ForEach(l => l.Remove());
            doc.DocumentNode.Descendants().Where(l => hList.Contains(l.Name)).ToList().ForEach(l => l.Name = "b");
            doc.DocumentNode.Descendants().Where(l => l.Attributes != null).ToList().ForEach(l => l.Attributes.ToList().ForEach(a => a.Remove()));
            doc.DocumentNode.Descendants().Where(l => !Whitelist.Contains(l.Name) && l.NodeType == HtmlNodeType.Element).ToList().ForEach(l => l.ParentNode.RemoveChild(l, true));
            return doc.DocumentNode.OuterHtml;
        }
        //lijst van tags die worden vervangen door <b></b>
        private List<string> hList = new List<string>
        {
            { "h1"},
            { "h2"},
            { "h3"},
            { "h4"},
            { "h5"},
            { "h6"}
        };
        List<string> Whitelist = new List<string>
        {
            { "p"},
            { "ul"},
            { "li"},
            { "br"},
            { "b"},
            { "table"},
            { "tr"},
            { "th"},
            { "td"},
            { "strong"}
        };
