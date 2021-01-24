      public DataSet RelaEspec(DateTime dtInicio, DateTime dtFim, string CodNo)
        {
            string sql = string.Empty;
            try
            {
                sql = "exec store_procedure @dtInicio, @dtFim, @CodNo ";
                SqlParameterCollection pCol = new SqlParameterCollection();
                pCol.Add("@dtInicio", SqlDbType.DateTime, dtInicio);
                pCol.Add("@dtFim", SqlDbType.DateTime, dtFim);
                pCol.Add("@CodNo", SqlDbType.VarChar, -1, CodNo);
                return ExecuteDataSet(sql, pCol, SessionID, connectionTimeout);
            }
            catch (Exception ex)
            {
                logErro(ex, "DataSet RelatorioEspecializacao");
                return null;
            }
        }
