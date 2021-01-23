    private static void Connect<TConnection, TCommand>(ExportManifest m_settings,
            Func<string, TConnection> createConnection,
            Func<string, TConnection, TCommand> createCommand)
        where TConnection : IDbConnection
        where TCommand : IDbCommand
    {
        using (TConnection mySqlConnection =
            createConnection(m_Settings.TargetData.ConnectionString))
        {
            TCommand mySqlCommand =
                createCommand(Program.GetCommandTextTemplate(m_settings), mySqlConnection);
            PrepareSqlCommand(mySqlConnection, mySqlCommand, m_settings);
        }
    }
    private static void PrepareSqlCommand<TConnection, TCommand>(TConnection sqlConnection,
            TCommand sqlCommand, ExportManifest m_settings)
        where TConnection : IDbConnection
        where TCommand : IDbCommand
    {
        sqlConnection.Open();
    }
