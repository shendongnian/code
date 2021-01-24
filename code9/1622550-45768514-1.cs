     public void CloseConnections()
        {
            foreach (var connection in connectionrepositroylist)
            {
                try
                {
                    if (connection.State == System.Data.ConnectionState.Open) // check other conditions
                    {
                        connection.Close();
                    }
                }
                catch (Exception)
                {
                    //logging or special handling
                }
            }
        }
