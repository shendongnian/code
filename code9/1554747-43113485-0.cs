     ListItem li = new ListItem(DateTime.Now.ToString("yyyy/MM"), DateTime.Now.ToString("yyyy/MM"));
                ddlStartPeriod.Items.Add(li);
                ListItem li2 = new ListItem(DateTime.Now.AddMonths(-1).ToString("yyyy/MM"), DateTime.Now.AddMonths(-1).ToString("yyyy/MM"));
                ddlStartPeriod.Items.Add(li2);
                ListItem li3 = new ListItem(DateTime.Now.AddMonths(-2).ToString("yyyy/MM"), DateTime.Now.AddMonths(-2).ToString("yyyy/MM"));
                ddlStartPeriod.Items.Add(li3);
