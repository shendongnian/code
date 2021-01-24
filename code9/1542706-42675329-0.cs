                int event_id = 0;
                using (OracleConnection oraConn = new OracleConnection(connStr))
                {
                    string cmdText = @"insert into EVENT
                        (EVENT_NAME, EVENT_DESC)
                        values
                        (:EVENT_NAME, :EVENT_DESC)
                        RETURNING EVENT_ID INTO :EVENT_ID
                        ";
    
                    using (OracleCommand cmd = new OracleCommand(cmdText, oraConn))
                    {
                        oraConn.Open();
                        OracleTransaction trans = oraConn.BeginTransaction();
                        try
                        {
                            OracleParameter prm = new OracleParameter();
                            cmd.BindByName = true;
                            prm = new OracleParameter("EVENT_NAME", OracleDbType.Varchar2); prm.Value = "SOME NAME"; cmd.Parameters.Add(prm);
                            prm = new OracleParameter("EVENT_DESC", OracleDbType.Varchar2); prm.Value = "SOME DESC"; cmd.Parameters.Add(prm);
                            prm = new OracleParameter("EVENT_ID", OracleDbType.Int32, ParameterDirection.ReturnValue); cmd.Parameters.Add(prm);
    
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                            // return value
                            event_id = ConvertFromDB<int>(cmd.Parameters["EVENT_ID"].Value);
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                        finally
                        {
                            trans.Dispose();
                        }
                        oraConn.Close();
                    }
                } 
