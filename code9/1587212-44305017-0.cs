    settings.TabPages.Add(tabpage =>
    {
        tabpage.Name = "TabPage1";
        tabpage.Text = "Page 1";
        tabpage.SetContent(() =>
        {
            ViewContext.Writer.Write(String.Format("<div id='{0}' >", tabpage.Name));
            Html.RenderAction(tabpage.Name);
            ViewContext.Writer.Write("</div>");
        });
    });
