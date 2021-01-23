            HtmlGenericControl c = new HtmlGenericControl("div");
            c.Attributes.Add("id", "menu");
            HtmlGenericControl ul1 = new HtmlGenericControl("ul");
            c.Controls.Add(ul1);
            HtmlGenericControl li1 = new HtmlGenericControl("li");
            li1.InnerText = "Dashboard";
            ul1.Controls.Add(li1);
            mainDiv.Controls.Add(c);
