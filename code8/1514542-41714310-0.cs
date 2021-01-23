    public List<string> GetActionNames()
    {
        return typeof(HomeController)
            .GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
            .Where(method => method.ReturnType.IsSubclassOf(typeof(ActionResult)) || method.ReturnType == typeof(ActionResult))
            .Select(method => method.Name)
            .ToList();
    }
