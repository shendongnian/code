    conn = new OleDbConnection(Conexao.getConexaoPainelGerencialLocal());
    OleDbCommand cmd = new OleDbCommand();
    OleDbTransaction transaction = null;
    
    try {
    
        conn.Open();
        transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        cmd.Connection = conn;
        cmd.Transaction = transaction;
        cmd.CommandText = " DELETE * FROM tblClienteContato; ";
        cmd.ExecuteNonQuery();
    
        cmd.CommandText = " INSERT INTO tblClienteContato " +
                           " SELECT * FROM tblClienteContatoVinculada;";
        cmd.ExecuteNonQuery();
        // The data isn't _finally_ completed until this happens
        transaction.Commit();
    
    }
    catch (Exception ex)
    {
        // Something has gone wrong.
        // do whatever error messaging you do
        Console.WriteLine(ex.Message);
        try
        {
            // Attempt to roll back the transaction.
            // this means your records won't be deleted
            transaction.Rollback();
        }
        catch
        {
            // Do nothing here; transaction is not active.
        }
    }
