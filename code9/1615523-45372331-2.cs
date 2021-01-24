            public void Connect(IPAddress address, string username, string password, string subRoot)
        {
            try
            {
                if ((connection != null) || ( scope != null))
                    throw new AlreadyConnectedException("A WMI connection already exists");
                connection = new ConnectionOptions();
                if (NetworkUtility.IsLocalIpAddress(address))
                {
                    connection.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                }
                else
                {
                    connection.Username = username;
                    connection.Password = password;
                    connection.Authority = "ntlmdomain:";
                }
                scope = new ManagementScope("\\\\" + address.ToString() + "\\root\\" + subRoot, connection);
                //Connecting with remote machine
                if (!scope.IsConnected)
                    scope.Connect();
            }
            catch (Exception ex)
            {
                ex.Data.Add("Address", address.ToString());
                ex.Data.Add("Username", username);
                ex.Data.Add("Password", password);
                ex.Data.Add("WMI Namespace", subRoot);
                throw;
            }
         }
