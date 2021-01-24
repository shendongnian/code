        if (Context.User.Identity.Name != "admin" && Context.User.Identity.Name != "")
        {
            HtmlGenericControl menu = (HtmlGenericControl)LogSection.FindControl("menu");
            HtmlGenericControl list = (HtmlGenericControl)menu.FindControl("list");
            HtmlGenericControl li = (HtmlGenericControl)list.FindControl("tabadmin");
            li.Visible = false;
        }
