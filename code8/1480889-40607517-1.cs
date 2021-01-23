    protected override void RenderContents(HtmlTextWriter writer)
    {
        base.RenderContents(writer);
        if (list.Any())
        {
            writer.Write("<ul>");
            foreach (var item in list)
                {
                    writer.Write("<li>" + item.Text + "</li>");
                }
            writer.Write("</ul>");
        }
    }
