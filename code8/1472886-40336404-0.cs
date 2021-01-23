    [HttpPost]
            [Route("A3Bans/searchBan")]
            public string oSearchBan(tBan ban)
            {
                {
                    tBan bans = new tBan();
                    string dbConnection = "datasource=127.0.0.1;port=3306;username=admin;password=00000";
                    MySqlConnection conDataBase = new MySqlConnection(dbConnection);
                    MySqlDataReader dbReader;
    //<Changes>
                    MySqlCommand SelectCommand = new MySqlCommand("select * from a3bans.bans where [GUID] =@prmGuid  ", conDataBase); // Returning a null value?!
        
                    selectCommand.Parameters.AddWithValue("@prmGuid", new Guid(ban.GuidOrIP));
    //</Changes end>
                    conDataBase.Open();
                    dbReader = SelectCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        tBan searchBan = new tBan();
                        searchBan.GuidOrIP = dbReader.GetString("GUID");
                        searchBan.BanType = dbReader.GetString("BanType");
                        searchBan.BanReason = dbReader.GetString("Reason");
                        searchBan.Proof = dbReader.GetString("Proof");
                        bans = searchBan;
                    }
                    dbReader.Close();
                    return bans.Proof;
    
    
                }
            }
