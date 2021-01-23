            string rootPath = Environment.GetEnvironmentVariable("TEMP");
            var rootDirectory = new DirectoryInfo(rootPath);
            DirectoryInfo subFolder = rootDirectory.CreateSubdirectory("SubFolder");
            var directorySecurity = subFolder.GetAccessControl();
            var adminitrators = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
            directorySecurity.AddAccessRule(
                new FileSystemAccessRule(
                        adminitrators,
                        FileSystemRights.FullControl,
                        InheritanceFlags.None,
                        PropagationFlags.NoPropagateInherit,
                        AccessControlType.Allow));
            directorySecurity.AddAccessRule(
                new FileSystemAccessRule(
                        WindowsIdentity.GetCurrent().Name,
                        FileSystemRights.FullControl,
                        InheritanceFlags.None,
                        PropagationFlags.NoPropagateInherit, 
                        AccessControlType.Allow));
            directorySecurity.SetAccessRuleProtection(isProtected: true, preserveInheritance: false);
            subFolder.SetAccessControl(directorySecurity);
