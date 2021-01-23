    class myclass
    {
         public DataTable SelectData(string proc, SqlParameter[] param)
         {
                DataTable Table = new DataTable();
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = proc;
                Cmd.Connection = Acces.Connection;
                if (param != null)
                    for (int i = 0; i < param.Length; i++)
                    {
                        Cmd.Parameters.Add(param[i]);
                    }
                SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
                Adapter.Fill(Table);
    
                return Table;
            }
         }
