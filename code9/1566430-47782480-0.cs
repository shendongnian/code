    public class MyMarkupFormatter : IMarkupFormatter
    {
        String IMarkupFormatter.Comment(IComment comment)
        {
            return String.Empty;
        }
        String IMarkupFormatter.Doctype(IDocumentType doctype)
        {
            return String.Empty;
        }
        String IMarkupFormatter.Processing(IProcessingInstruction processing)
        {
            return String.Empty;
        }
        String IMarkupFormatter.Text(String text)
        {
            return text;
        }
        String IMarkupFormatter.OpenTag(IElement element, Boolean selfClosing)
        {
            switch (element.LocalName)
            {
                case "p":
                    return "\n\n";
                case "br":
                    return "\n";
                case "span":
                    return " ";
            }
            return String.Empty;
        }
        String IMarkupFormatter.CloseTag(IElement element, Boolean selfClosing)
        {
            return String.Empty;
        }
        String IMarkupFormatter.Attribute(IAttr attr)
        {
            return String.Empty;
        }
    }
