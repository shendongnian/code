            public TokenResponse GetToken()
        {
            UserCredential credentail;
            try
            {
                string[] scopes = new string[] { BigqueryService.Scope.Bigquery,    // view and manage your BigQuery data
                                    BigqueryService.Scope.BigqueryInsertdata ,  // Insert Data into Big query
                                    BigqueryService.Scope.CloudPlatform,        // view and manage your data acroos cloud platform services
                                    BigqueryService.Scope.DevstorageFullControl,// manage your data on Cloud platform services
                                    BigqueryService.Scope.DevstorageReadOnly ,  // view your data on cloud platform servies
                                    BigqueryService.Scope.DevstorageReadWrite };
                credentail = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    _clientSecret,
                    scopes,
                    "reports"
                    , CancellationToken.None
                    , new FileDataStore("Store")
                    ).Result;
                if (credentail != null)
                    return credentail.Token;
                else
                {
                    _log.WriteToAll("Invalid credentials", EventLogEntryType.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _log.WriteToAll(ex);
                return null;
            }
        }
