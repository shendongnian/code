    public WqlConnectionManager Connect(string serverName, string userName, string userPassword)
    {
        try
        {
            SmsNamedValuesDictionary namedValues = new SmsNamedValuesDictionary();
            WqlConnectionManager connection = new WqlConnectionManager(namedValues);
    
            if (System.Net.Dns.GetHostName().ToUpper() == serverName.ToUpper())
            {
                // Connect to local computer.
                connection.Connect(serverName);
            }
            else
            {
                // Connect to remote computer.
                connection.Connect(serverName, userName, userPassword);
            }
    
            return connection;
        }
        catch (SmsException e)
        {
            Console.WriteLine("Failed to Connect. Error: " + e.Message);
            return null;
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Failed to authenticate. Error:" + e.Message);
            return null;
        }
    }
    
