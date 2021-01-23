    public static void UpdateDBtCowsCalculatedVariable() {
    //int BW, DaysInMilk, AnimalType;
    string StrCon = System.Configuration.ConfigurationManager.ConnectionStrings["FeedLibraryConnectionString"].ConnectionString;
    OleDbConnection Connection = new OleDbConnection(StrCon);
    OleDbCommand Cmd = new OleDbCommand();
    Cmd.Connection = Connection;
    Cmd.CommandText = "Select BW, DaysInMilk, AnimalType from tCows";
    Connection.Open();
    reader = Cmd.ExecuteReader();
    while (reader.Read())
    {
      int BW = reader.GetValue(0);
      int DaysInMilk =  reader.GetValue(1);
      int AnimalType =  reader.GetValue(2);
    }
    reader.Close();
    Connection.Close();
    }
