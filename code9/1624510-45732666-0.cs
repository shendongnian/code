    using (SPSite site = new SPSite(http://sharepointSiteWithList))
        {
            using (SPWeb web = site.OpenWeb())
            {
                SPList list = web.Lists["listName"];
                dd.DataSource = list.Items;
                dd.DataValueField = "Department";
                dd.DataTextField = "Department";
                dd.DataBind();
            }
        }
