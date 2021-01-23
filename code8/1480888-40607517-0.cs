    protected override void RenderContents(HtmlTextWriter writer)
    {
        base.RenderContents(writer);
        foreach (var item in list)
            {
                writer.Write(item.Text + "<br/>");
            }
    }
