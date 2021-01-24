    private static void PrintFolderPermission(string webUri, string listTitle)
    {
        using (var ctx = new ClientContext(webUri))
        {
            var list = ctx.Web.Lists.GetByTitle(listTitle);
            var query = CamlQuery.CreateAllFoldersQuery();
            query.FolderServerRelativeUrl = "/sites/custom-dev/Shared documents/MyFolder/MySubfolder";
            var items = list.GetItems(query);
            ctx.Load(items, icol => icol.Include(i => i.RoleAssignments.Include(ra => ra.Member), i => i.DisplayName));
            ctx.ExecuteQuery();
            foreach (var item in items)
            {
                Debug.WriteLine(item.DisplayName + " folder permissions");
                foreach (var assignment in item.RoleAssignments)
                {
                    Debug.WriteLine(assignment.Member.Title);
                }
            }
        }
    }
