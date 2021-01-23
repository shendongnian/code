      var list = new ListItem[] {
               new ListItem("number 01","1"),
                new ListItem("number 02","2"),
                new ListItem("number 03","3"),
               new ListItem("number 04","4"),
                new ListItem("number 05","5")
            };
            lst.Items.AddRange(list);
            lst.DataBind();
            var strPrint = new StringBuilder(string.Empty);
            foreach (ListItem item in lst.Items)
            {
                strPrint.AppendLine(item.Text);
            }
            Response.Write(strPrint);
