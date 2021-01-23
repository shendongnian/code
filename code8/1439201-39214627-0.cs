    public static void UpdateDBtCowsCalculatedVariable()
    {
        string StrCon = ...
        int BW = -1; 
        int DaysInMilk = -1;
        int AnimalType = -1;
           
        using (OleDbConnection Connection = new OleDbConnection(StrCon)) 
        {
            Connection.Open();
    
            using (OleDbCommand Cmd = new OleDbCommand())
            {
                Cmd.Connection = Connection;
                Cmd.CommandText = 
                  @"select BW, 
                           DaysInMilk, 
                           AnimalType 
                      from tCows";
    
                using (var reader = Cmd.ExecuteReader())
                {
                    if (reader.Read()) 
                    {
                        BW =         Convert.ToInt32(reader.GetValue(0));
                        DaysInMilk = Convert.ToInt32(reader.GetValue(1));
                        AnimalType = Convert.ToInt32(reader.GetValue(2));   
                    }
                }
    
            }
        }
    }
