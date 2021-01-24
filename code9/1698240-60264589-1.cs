        static List<string> GetGroupOwnersOutlook(GroupPrincipal group)
        {
            List<string> owners = new List<string>();
            DirectoryEntry deGroup = group.GetUnderlyingObject() as DirectoryEntry;
            System.DirectoryServices.PropertyCollection r = deGroup.Properties;
            foreach (string a in r["managedBy"])
            {
                owners.Add(a);
            }
            foreach (string a in r["msExchCoManagedByLink"])
            {
                owners.Add(a);
            }
            
            return owners;
        }
