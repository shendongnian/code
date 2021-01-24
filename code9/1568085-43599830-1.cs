    using (conn = new OleDbConnection(Conexao.getConexaoPainelGerencialLocal())) {
        conn.Open();
        using (OleDbCommand cmd = new OleDbCommand()) {
            cmd.CommandText = "TRUNCATE TABLE tblClienteContato; ";
            cmd.ExecuteNonQuery();
            cmd.CommandText = " INSERT INTO tblClienteContato " +
                " SELECT * FROM tblClienteContatoVinculada;";
            cmd.ExecuteNonQuery();
        }
    }
