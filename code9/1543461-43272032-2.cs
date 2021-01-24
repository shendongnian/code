    public PowerBIContext PowerBIContext{
            get
            {
                if (_PowerBIContext == null)
                {
                    string ticket = GetTicket();
                    if (!string.IsNullOrEmpty(ticket))
                    {
                        int company = GetUserCompany(ticket);
                        if (company > 0)
                        {
                            string connectionString = GetPowerBIConnectionString(company);
                            if (!string.IsNullOrEmpty(connectionString))
                            {
                                _PowerBIContext = new PowerBIContext(connectionString);
                            }
                        }                        
                    }                    
                }
                return _PowerBIContext;
            }
            
            private set {}
        }
