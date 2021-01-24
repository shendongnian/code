            OpenConnection();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = spName;
            sqlcmd.Connection = sqlconn;
            if (System.Convert.IsDBNull(cmdparam) == false)
            {
                SqlParameter parm;
                foreach (SqlParameter parm_loopVariable in cmdparam)
                {
                    parm = parm_loopVariable;
                    sqlcmd.Parameters.Add(parm);
                }
            }
            SqlParameter tvpParam = sqlcmd.Parameters.AddWithValue("@Type", Your 
            Datatable); 
            tvpParam.SqlDbType = SqlDbType.Structured; 
            SqlParameter returnParameter = sqlcmd.Parameters.Add("RetVal", 
             SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlcmd.ExecuteNonQuery();
            int Result = (int)returnParameter.Value;
            sqlcmd.Dispose();
            return Result;
