    protected bool TryLoadPlayerData(PlayerConnection playerConnection, string sso)
    {
        try
        {
            SetPlayer(playerConnection);
    
            using (var databaseConnection = Hariak.HariakServer.Database.NewDatabaseConnection)
            {
                databaseConnection.SetQuery("SELECT * FROM `users` WHERE `auth_ticket` = @sso LIMIT 1;");
                databaseConnection.AppendParameter("sso", sso);
    
    
                using (MySqlDataReader reader = databaseConnection.ExecuteReader())
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                        {
                            dictionary.Add(reader.GetName(i), reader.GetValue(i));
                        }
                }
            }
    
            Logger.Info("Loaded PlayerData for " + SelectColumn("username"));
            return true;
        }
        catch (Exception exception)
        {
            Logger.Error(exception, "Failed to load PlayerData for player.");
            return false;
        }
    }
