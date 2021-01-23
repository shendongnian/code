    using (NpgsqlCommand command = new NpgsqlCommand(
        "select Fifty(:CDE, :CPARA, :VDE, :VPARA, :IDP)", this.dllConexao.ConexaoBd))
    {
        if (!dllConexao.open(Processadora.Comum.tipoConexao, 1, true))
        {
            clsRetorno.ret = 99;
            clsRetorno.msg = "Sistema temporariamente indisponível, " +
               "tente novamente mais tarde";
        }
        if (this.dllConexao.transactionIsOpen())
        {
            command.Transaction = this.dllConexao.TransacaoBd;
        }
        command.Parameters.Add("CDE", NpgsqlDbType.Bigint);
        command.Parameters.Add("CPARA", NpgsqlDbType.Bigint);
        command.Parameters.Add("VDE", NpgsqlDbType.Numeric);
        command.Parameters.Add("VPARA", NpgsqlDbType.Numeric);
        command.Parameters.Add("IDP", NpgsqlDbType.Bigint);
        command.Parameters[0].Value = cpfDe;
        command.Parameters[1].Value = cpfPara;
        command.Parameters[2].Value = valorDe;
        command.Parameters[3].Value = valorPara;
        command.Parameters[4].Value = idPagamento;
        command.ExecuteScalar();
        this.dllConexao.commitTransacao();
        this.dllConexao.closeTransaction();
    }
