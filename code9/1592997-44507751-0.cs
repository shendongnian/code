    using (RegistryKey key = Registry.LocalMachine.OpenSubKey("software"))
    {
        var security = key.GetAccessControl();
        var rules = security.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
        foreach (var rule in rules.Cast<AuthorizationRule>())
        {
            Console.WriteLine(rule.IdentityReference.ToString());
        }
    }
