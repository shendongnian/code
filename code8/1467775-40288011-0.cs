       security = regParent.GetAccessControl(AccessControlSections.All);
    
        security.AddAccessRule(new RegistryAccessRule(
            new SecurityIdentifier(WellKnownSidType.LocalSystemSid, null),
            RegistryRights.FullControl,
            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
            PropagationFlags.None, // Self+Children
            AccessControlType.Allow));
    
        security.AddAccessRule(new RegistryAccessRule(
            new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null),
            RegistryRights.FullControl,
            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
            PropagationFlags.None, // Self+Children
            AccessControlType.Allow));
    
        security.AddAccessRule(new RegistryAccessRule(
            new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null),
            RegistryRights.ReadPermissions | RegistryRights.ReadKey | RegistryRights.EnumerateSubKeys | RegistryRights.QueryValues,
            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
            PropagationFlags.None, // Self+Children
            AccessControlType.Allow));
    
        regParent.SetAccessControl(security);
