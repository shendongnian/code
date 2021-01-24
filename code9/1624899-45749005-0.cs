    using (SPWeb web = SPContext.Current.Web)
            {
                SPList list = web.Lists["list"];
                string title = "line for search";
                SPListItemCollection items = list.GetItems(new SPQuery()
                {
                    Query = @"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + title + "</Value></Eq></Where>"
                });
                if (items.Count > 0)
                {
                    mygrid.DataSource = items.GetDataTable();
                    mygrid.DataBind();
                }
                
            }
