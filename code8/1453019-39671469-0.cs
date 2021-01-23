      IList<string> actionNames=new List<string>();
        Assembly asm = Assembly.GetExecutingAssembly();
        var methodInfos = asm.GetTypes()
            .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
            .SelectMany(type => type.GetMethods())
            .Where(method => method.IsPublic &&method.CustomAttributes.Any(a=>a.AttributeType==typeof(ActionNameAttribute)));
        foreach (var methodInfo in methodInfos)
        {
            var actionAttribute =
                methodInfo.CustomAttributes.First(a => a.AttributeType == typeof(ActionNameAttribute));
            var actionName = actionAttribute.ConstructorArguments.First().Value;
            actionNames.Add(actionName.ToString());
        }
