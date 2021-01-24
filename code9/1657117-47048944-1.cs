    public static class AccessRoles
    {
        private static List<AccessRole> _roles;
        static AccessRoles()
        {
            _roles = new List<AccessRole>();
            // Here I populate it hard coded for the sample,
            // but it should be populated from your database or config file
            _roles.Add(new AccessRole(new Guid("2ED3164-BB48-499B-86C4-A2B1114BF1"), 1, "SysAdmin"));
            _roles.Add(new AccessRole(new Guid("A5690E7-1111-4AFB-B44D-1DF3AD66D435"), 2, "Admin"));
            _roles.Add(new AccessRole(new Guid("30558C7-66D9-4189-9BD9-2B87D11190"), 3, "OrgAdmin"));
        }
        
        public static AccessRole GetRole(Guid uuid)
        {
            return _roles.Find(r => r.Uuid == uuid);
        }
        
        public static AccessRole GetRole(int number)
        {
            return _roles.Find(r => r.Number == number);
        }
        
        public static AccessRole GetRole(string name)
        {
            return _roles.Find(r => r.Name == name);
        }
    }
