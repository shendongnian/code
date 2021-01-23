        private static void TransferXmlData(ExportManifest m_settings, XmlNodeList xmlNodeList)
        {
            if (m_Settings.ServerType.ToLower() == "mysql")
                Connect(connectionString => new MySqlConnection(connectionString),
                    (text, connection) => new MySqlCommand(text, connection));
            else
                Connect(connectionString => new SqlConnection(connectionString),
                        (text, connection) => new SqlCommand(text, connection));
        }
        private static void Connect(ExportManifest m_settings,
                Func<string, IDbConnection> createConnection,
                Func<string, IDbConnection, IDbCommand> createCommand)
        {
            using (IDbConnection mySqlConnection =
                createConnection(m_Settings.TargetData.ConnectionString))
            {
                IDbCommand mySqlCommand =
                    createCommand(Program.GetCommandTextTemplate(m_settings), mySqlConnection);
                PrepareSqlCommand(mySqlConnection, mySqlCommand, m_settings);
            }
        }
        private static void PrepareSqlCommand(IDbConnection sqlConnection,
            IDbCommand sqlCommand, ExportManifest m_settings)
        {
            sqlConnection.Open();
        }
