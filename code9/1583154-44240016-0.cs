     static void Main()
            {
                string siteUrl = "Your site url";
                ClientContext clientContext = new ClientContext(siteUrl);
                var list = clientContext.Web.Lists.GetByTitle("JZhu");
                var items = list.GetItems(CamlQuery.CreateAllItemsQuery());
                clientContext.Load(items);
                clientContext.ExecuteQuery();
                clientContext.Load(clientContext.Web.SiteGroups);
                clientContext.ExecuteQuery();
                GroupCollection oSiteCollectionGroups= clientContext.Web.SiteGroups;
                foreach (Group grp in oSiteCollectionGroups)
                {
                    Console.WriteLine(grp.Title);
                    if (grp.Title == "My group")
                    {
                        oGroup=gpr;
                        break;
                    }
                }
                foreach (var item in items)
                {
                    var folder = GetListItemFolder(item); //get Folder
                    Console.WriteLine(folder.Name);
                    if (folder.Name=="Folder 1" || folder.Name=="Folder 2")
                    {
                        item.BreakRoleInheritance(false);
                        RoleDefinitionBindingCollection collRoleDefinitionBinding = new RoleDefinitionBindingCollection(clientContext);
                        //set role type
                        collRoleDefinitionBinding.Add(clientContext.Web.RoleDefinitions.GetByType(RoleType.Reader));
                        //oGroup - your group
                        item.RoleAssignments.Add(oGroup, collRoleDefinitionBinding);
                        clientContext.ExecuteQuery();
                    }
                }
            }
            private static Folder GetListItemFolder(ListItem listItem)
            {
                var folderUrl = (string)listItem["FileDirRef"];
                var parentFolder = listItem.ParentList.ParentWeb.GetFolderByServerRelativeUrl(folderUrl);
                listItem.Context.Load(parentFolder);
                listItem.Context.ExecuteQuery();
                return parentFolder;
            }
