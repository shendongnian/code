    public string GetMenu(Node currentPage)
    {
        var stringWriter = new StringWriter();
        using (var htmlWriter = new HtmlTextWriter(stringWriter))
        {
            RenderMenu(currentPage, writer);
        }
        return stringWriter.ToString();
    }
    private void RenderMenu(Node node, HtmlTextWriter writer)
    {
        // Mostly copied from the code in the question...
        foreach (var item in currentPage.ChildrenAsList)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Li);
            writer.AddAttribute(HtmlTextWriterAttribute.Href, item.Url);
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write(item.Name);
            if (item.ChildrenAsList.Any())
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                // Note the change here
                RenderMenu(new Node(item.Id), writer));
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
            writer.RenderEndTag();
        }
    }
