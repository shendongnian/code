        static List<string> GetGroupOwners(GroupPrincipal group)
        {
            List<string> owners = new List<string>();
            DirectoryEntry deGroup = group.GetUnderlyingObject() as DirectoryEntry;
            ActiveDirectorySecurity ads = deGroup.ObjectSecurity;
            AuthorizationRuleCollection rules = ads.GetAccessRules(true, true, typeof(SecurityIdentifier));
            Guid exRight_Member = new Guid("{bf9679c0-0de6-11d0-a285-00aa003049e2}");
            foreach (ActiveDirectoryAccessRule ar in rules)
            {
                if (ar.ActiveDirectoryRights.HasFlag(ActiveDirectoryRights.GenericWrite) || (ar.ObjectType.Equals(exRight_Member) && ar.ActiveDirectoryRights.HasFlag(ActiveDirectoryRights.WriteProperty)))
                {
                    string friendlyName = "";
                    try
                    {
                        friendlyName = ar.IdentityReference.Translate(typeof(NTAccount)).Value;
                    }
                    catch
                    {
                    }
                    owners.Add(friendlyName);
                }
            }
            return owners;
        }
