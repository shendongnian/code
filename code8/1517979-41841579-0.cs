    var parentTasks = parents.Select(async (par) => {
     var childTasks = par.ChildItems.Select(async (sub) => {
       sub.StatusName = await ChangeChildStatusName(sub.StatusId);
       return sub;
     });
     par.ChildItems = (await Task.WhenAll(childTasks)).ToList();
     return par;
    });
    parents = (await Task.WhenAll(parentTasks)).ToList();
