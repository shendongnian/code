    var controllers = Assembly.GetAssembly(typeof(CreditLogCreditSumController))
        .GetTypes()
        .Where(type => type.IsClass
                       && type.IsSubclassOf(typeof(Controller))
                       && type.GetCustomAttributes(typeof(RoleAuthorize), false).Any());
