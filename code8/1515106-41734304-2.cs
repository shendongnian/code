    public class ConnectionClass
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["xyz"].ConnectionString;
        public SqlConnection conTrans = new SqlConnection();
        public SqlTransaction dbTrans;
        public SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        public SqlTransaction sqlTrans;
             
        public bool BeginConTrans()
        {
            try
            {
                conTrans.ConnectionString = ConnectionString;
                conTrans.Open();
                dbTrans = conTrans.BeginTransaction();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CommitConTrans()
        {
            try
            {
                dbTrans.Commit();
                conTrans.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool RollbackConTrans()
        {
            try
            {
                dbTrans.Rollback();
                conTrans.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ExecuteNonQueryTrans(string proc, SqlParameter[] par)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                if (par != null)
                {
                    for (int i = 0; i <= par.Length - 1; i++)
                    {
                        cmd.Parameters.Add(par[i]);
                    }
                }
                cmd.Connection = conTrans;
                cmd.Transaction = dbTrans;
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
