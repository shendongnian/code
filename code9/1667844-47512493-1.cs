        using (var context = new System.DirectoryServices.AccountManagement.PrincipalContext(ContextType.Domain))
        {
            server = context.ConnectedServer; 
            //Output : dc.example.com
            var formatted = server.Split('.').Select(s => String.Format("DC={0}", s));
            joined = String.Join(",", formatted); 
            // Output DC=dc,DC=example,DC=com
        }
