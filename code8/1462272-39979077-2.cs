    var Links = links.Controls.OfType<HtmlGenericControl>().ToArray();
    foreach (HtmlGenericControl li in Links)
    {
        if (BW_Access.accessApp(li, "Read") == false)
        {
            li.Visible = false;
        }
    }
