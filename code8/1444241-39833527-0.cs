    using (SPWeb oWebsiteRoot = SPContext.Current.Site.RootWeb)
            {
                SPGroupCollection collGroups = oWebsiteRoot.SiteGroups;
                foreach(SPGroup group in collGroups)
                {
                    for(int i=group.Users.Count; i>=0;i--)
                    {
                        SPUser user = group.Users[i];
                        if (listOfDecimalsToBeDeleted.Contains(getUserDecimalPart(user.LoginName)))
                        {
                            group.RemoveUser(user);
                        }
                    }
                }
            }
