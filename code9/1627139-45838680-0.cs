    //DAL
    public Client ExecuteView(String Fname, ref String lname, ref String age, ref bool exist)
    {
        try
        {
            //using (var command = new SqlCommand("DisplayInfo", con))
            using (IDbConnection db = new SqlConnection(c.connstr))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
    
                DynamicParameters param = new DynamicParameters();
                param.Add("@Fname", Fname);
                param.Add("@exist", dbType: DbType.Boolean, direction:
                    ParameterDirection.Output);
                SqlDbType.int, ParameterDirection.Output);
                var cl = new Client();
                cl = con.Query<Client>("DisplayInfo", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
    
                exist = param.Get<bool>("@exist");
    
                if (db.State != ConnectionState.Closed)
                {
                    db.Close();
                }
                return client;
            }
        }
