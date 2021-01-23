    using AngleSharp.Dom;
    using AngleSharp.Dom.Html;
    using AngleSharp.Extensions;
    using AngleSharp.Parser.Html;
    private void processHTMLNode(INode node, IElement targetElement)
    {
        IElement elementNode;
        IText textNode;
        if ((elementNode = node as IElement) != null)
        {
            switch (node.NodeName.ToLower())
            {
                //...
                case "a":
                    if(node.HasAttribute("href") && node.GetAttribute("href").StartsWith("#"))
                    {
                        break;
                    }
                    var aNew = outputDocument.CreateElement("a");
                    aNew.SetAttribute("href", node.GetAttribute("href"));
                    foreach (var childNode in elementNode.ChildNodes)
                    {
                        processHTMLNode(childNode, aNew);
                    }
                    targetElement.AppendChild(aNew);
                    break;
                case "p":
                    var pNew = outputDocument.CreateElement("p");
                    foreach (var childNode in node.Children)
                    {
                        processHTMLNode(childNode, pNew);
                    }
                    targetElement.AppendChild(pNew);
                    break;
                //...
            }
                
        }
        else if ((textNode = node as IText) != null)
        {
            var newTextNode = outputDocument.CreateTextNode(textNode.Text);
            targetElement.AppendChild(newTextNode);
        }
    }
