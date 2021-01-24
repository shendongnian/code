        var lists = web.Lists;
        context.Load(lists, all => all
          .Where(l => l.RootFolder.Name == "Accounts")
          .Include(l => l.Id));
        context.ExecuteQuery();
        list = lists.Single();
