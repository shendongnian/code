     private MongoClientSettings GetSecuritySettingForConnection()
            {
                MongoClientSettings settings = new MongoClientSettings();
                settings.Server = new MongoServerAddress(host, port);
                MongoIdentity identity = new MongoInternalIdentity(authenticationDatabase, userName);
                MongoIdentityEvidence evidence = new PasswordEvidence(password);
                settings.Credentials = new List<MongoCredential>()
                {
                    new MongoCredential("SCRAM-SHA-1", identity, evidence)
                    
                };
                settings.MaxConnectionIdleTime = new TimeSpan(0, 2, 0);
                return settings;
            }
