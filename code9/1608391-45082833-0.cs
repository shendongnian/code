     public List<EnFormato> ListarReporteSegunPeriodoFecha(string psPeriodo,int piIdFormato , int piIdProceso, DateTime pdFechaProceso)
        {
            try
            {
                List<EnFormato> loEnFormato = new List<EnFormato>();
                SqlCommand cmd = new SqlCommand("[CTB_CONTA].[sENC_ListarReporteSegunPeriodoFecha]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pvPeriodoProceso", SqlDbType.VarChar).Value = psPeriodo;
                cmd.Parameters.Add("@piIdFormato", SqlDbType.Int).Value = piIdFormato;
                cmd.Parameters.Add("@piIdProceso", SqlDbType.Int).Value = piIdProceso;
                cmd.Parameters.Add("@pdFechaProceso", SqlDbType.Date).Value = pdFechaProceso;
                SqlDataReader drd = cmd.ExecuteReader();
                if (drd.HasRows)//!=null
                {
                    int pos_iDiaSaldo = drd.GetOrdinal("iDiaSaldo");
					while (drd.Read())
                    {
                        EnFormato oEnFormato = new EnFormato();
                        oEnFormato.iDia = drd.IsDBNull(pos_iDiaSaldo) ? 0 : drd.GetInt32(pos_iDiaSaldo);
                        loEnFormato.Add(oEnFormato);
                    }
                    drd.Close();
                }
                return (loEnFormato);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
