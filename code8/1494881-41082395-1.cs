    using (var context = new PrincipalContext(ContextType.Machine))
    {
        var users = new PrincipalSearcher(new UserPrincipal(context)).FindAll()
            .OfType<UserPrincipal>()
            .Where(u => u.GetGroups().Any(g => g.Name.StartsWith("A")))
            .Distinct()
            .Select(u => $"({u.Name}) {u.GivenName ?? "No GivenName"}, {u.Surname ?? "No Surname"}")
            .ToList();
        foreach (var u in users)
            Console.WriteLine(u);
    }
