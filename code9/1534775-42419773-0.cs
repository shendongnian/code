    int idnum = Convert.ToInt32(Console.ReadLine());
    string sql = "SELECT EXPID, TYPE, DATE_LATEST FROM TRAINING_TABLE where expid =" + idnum;
    //  I don't know how you're using this so I'll just declare it here 
    //  and leave that to you.
    String dateLabel = "";
    OracleCommand cmd = new OracleCommand();
    cmd.Connection = conn;
    cmd.CommandText = sql;
    using (DbDataReader reader = cmd.ExecuteReader())
    {
        DateTime? RWT010 = null;
        DateTime? RWT010BP = null;
        DateTime? RWP000 = null;
        //  No need to check reader.HasRows. If it has no rows, reader.Read()
        //  will return false the first time, that's all. 
        while (reader.Read())
        {
            //  Doesn't look to me like expid is used
            //int expid = reader.GetInt32(0);
            string trainType = reader.GetString(1);
            DateTime trainDate = reader.GetDateTime(2);
        
            switch (trainType) {
                case "RWT010":
                    RWT010 = trainDate;
                    break;
                case "RWT010BP":
                    RWT010BP = trainDate;
                    break;
                case "RWP000":
                    RWP000 = trainDate;
                    break;
            }
        }
        if (RWT010 == null || RWT010BP > RWT010) {
            dateLabel = String.Format("RWT010BP: {0:d}", RWT010BP);
        } else {
            dateLabel = String.Format("RWT010: {0:d} & RWP000: {1:d}", RWT010, RWP000); 
        }
    }
