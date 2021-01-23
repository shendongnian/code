    var Links = links.Controls.OfType<HtmlGenericControl>().ToArray();
    foreach (HtmlGenericControl li in Links)
    {
        li.Visible = false;
    }
