    static void MergeStyles(string xml)
    {
        XDocument doc = XDocument.Parse(xml);
        var desc = doc.Document.Elements();
        Go(doc.Root, new List<string>());
        Console.WriteLine(target);
    }
    
    static string target = "";
    static void Go(XElement node, List<string> styles)
    {
        foreach (var child in node.Nodes())
        {
            if (child.NodeType == XmlNodeType.Text)
            {
                if (styles.Count > 0)
                {
                    target += string.Format(
                        "<content styleCode=\"{0}\">{1}</content>",
                        string.Join(" ", styles.Select(s => s.ToLower())),
                        child.ToString(SaveOptions.DisableFormatting));
                }
                else
                {
                    target += child.ToString(SaveOptions.DisableFormatting);
                }
            }
            else if (child.NodeType == XmlNodeType.Element)
            {
                var element = (XElement)child;
                if (element.Name == "content")
                {
                    string style = element.Attributes("styleCode").Single().Value;
                    styles.Add(style);
                    Go(element, styles);
                    styles.RemoveAt(styles.Count - 1);
                }
            }
        }
    }
