        public IEnumerable<string> Get()
        {
            // Query service to check status
            ServiceStatusHub.GetStatus("Please check status of the LDAP!");
            return new string[] { "val1", "val2" };
        }
