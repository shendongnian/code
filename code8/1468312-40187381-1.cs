    private static void TransferXmlData(ExportManifest m_settings, XmlNodeList xmlNodeList)
    {
        IDbConnection db = factory.createDbInstance(m_settings);
                    db.ConnectionString = m_Settings.TargetData.ConnectionString;
                    IDbCommand comnd = db.CreateCommand();
        
                    comnd.CommandText = Program.GetCommandTextTemplate(m_settings);
                    comnd.CommandType = CommandType.Text;
                   // db.Open(); if you want to open connection here
                    PrepareSqlCommand(db, comnd, m_settings);
}
    private static void PrepareSqlCommand(IDbConnection sqlConnection, IDbCommand sqlCommand, ExportManifest m_settings)
    {
        // Potentially a lot of code here that looks just like the 
        // code in the else block, Except that it uses the 
        // MySqlConnection objects instead of SqlConnection
        // Do some stuff
        sqlConnection.Open();  // obviously doesn't work
    }
