            var server = "<SERVER:PORT>";
            var adminUser = "<USERNAME>";
            var adminPass = "<PASSWORD>";
            using (var ldap = new LdapConnection(server))
            {
                ldap.SessionOptions.ProtocolVersion = 3;
                // To simplify this example I'm not validating certificate. Your code is fine.
                ldap.SessionOptions.VerifyServerCertificate += (connection, certificate) => true;
                ldap.SessionOptions.SecureSocketLayer = true;
                ldap.AuthType = AuthType.Basic;
                ldap.Bind(new System.Net.NetworkCredential($"cn={adminUser},o=<ORGANIZATION>", adminPass));
                // Now I will search to find user's DN.
                // If you know exact DN, then you don't need to search, go to compare request directly.
                var search = new SearchRequest
                {
                    //Here goes base DN node to start searching. Node closest to entry improves performance.
                    // Best base DN is one level above.
                    DistinguishedName = "<BASEDN>", //i.e.: ou=users,o=google
                    Filter = "uid=<USERNAME>",
                    Scope = SearchScope.OneLevel
                };
                
                // Adding null to attributes collection, makes attributes list empty in the response.
                // This improves performance because we don't need any info of the entry.
                search.Attributes.Add(null);
                var results = (SearchResponse)ldap.SendRequest(search);
                if (results.Entries.Count == 0)
                    throw new Exception("User not found");
                // Because I'm searching "uid" can't exists more than one entry.
                var entry = results.Entries[0];
                
                // Here I use DN from entry found.
                var compare = new CompareRequest(entry.DistinguishedName, new DirectoryAttribute("userPassword", "<PASSWORD>"));
                var response = (CompareResponse)ldap.SendRequest(compare);
                if (response.ResultCode != ResultCode.CompareTrue)
                    throw new Exception("User and/or Password incorrect.");
            }
