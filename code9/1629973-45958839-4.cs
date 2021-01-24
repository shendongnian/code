    public static void CheckForDuplicateActionId()
    {
        Assembly asm = Assembly.GetExecutingAssembly();
        var controllerActionlist = asm.GetTypes()
            .Where(type => typeof(Controller).IsAssignableFrom(type))
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly |
                                                BindingFlags.Public))
            .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute),
                true).Any())
            .Where(m => m.GetCustomAttribute<YcoPageIdAttribute>() != null)
            .Select(
                x =>
                    new
                    {
                        Controller = x.DeclaringType.Name,
                        Area = x.DeclaringType.FullName,
                        Action = x.Name,
                        ReturnType = x.ReturnType.Name,
                        Id = x.GetCustomAttribute<YcoPageIdAttribute>().PageId
                    })
            .ToList();
        var actionIds = controllerActionlist.Select(x => x.Id).ToList();
        var actionIdsGrouped = actionIds.GroupBy(x => x).Where(x => x.Count() > 1).ToList();
        if (!actionIdsGrouped.IsNullOrEmpty()) 
        {
            StringBuilder error = new StringBuilder("");
            actionIdsGrouped.ForEach(actionId =>
            {
                var actions = controllerActionlist.Where(x => x.Id == actionId.Key);
                actions.ForEach(a =>
                {
                    error.Append(
                        $" | Id : {a.Id}, Action Name: {a.Action}, Controller Name : {a.Controller}, Location : {a.Area}. ");
                });
            });
            var maxId = controllerActionlist.Max(x => x.Id);
            error.Append(
                "PLease consider changing the the duplicated id - Here are some options to choose from : Id {");
            for (int i = 1, j = 1; i < maxId + 5; i++)
            {
                if (actionIds.Contains(i)) continue;
                if (j < 5)
                {
                    error.Append(i + ",");
                    j++;
                }
                else
                {
                    error.Append(i + "}");
                    break;
                }
            }
            throw new Exception(
                $"There are more than one action duplicated with the same Id, The action data are as below : {error}");
        }
    }
