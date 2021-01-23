                List<string> recipients = new List<string>();
                string siteURL = @"myurl/";
                ClientContext cc = new ClientContext(siteURL);
                cc.Credentials = System.Net.CredentialCache.DefaultCredentials;
                Web web = cc.Web;
                List list = web.Lists.GetById(new Guid(cbxMailDistributionList.SelectedValue.ToString()));
                CamlQuery caml = new CamlQuery();
                ListItemCollection items = list.GetItems(caml);
                cc.Load<List>(list);
                cc.Load<ListItemCollection>(items);
                cc.ExecuteQuery();
                foreach (Microsoft.SharePoint.Client.ListItem item in items)
                {
                    if(item.FieldValues["Title"] == null) { }
                    else
                    {
                        if (recipients.Contains(item.FieldValues["Title"].ToString())) { }
                        else
                        {
                            recipients.Add(item.FieldValues["Title"].ToString());
                        }
                    }
                }
                recipients.Sort();
                distributionList = recipients;
            }
            else
            {
                distributionList = null;
            }
