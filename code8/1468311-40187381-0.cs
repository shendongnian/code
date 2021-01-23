    Public class factory
        {
            public static IDbConnection createDbInstance(ExportManifest m_settings)
            {
                if (m_Settings.ServerType.ToLower() == "mysql")
                {
                     return new MySqlConnection();
                    
                }
    
                else
                   return new SqlConnection();
            }
        } `
