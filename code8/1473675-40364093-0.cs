    //Reuse the same command with different connections
    void InitializePlayerCmd()
    {
        var query = "SELECT COUNT(*) FROM life.players where DBName=@name and DbPass=@pass";
        var myCmd= new MySqlCommand(query);
        myCmd.Parameters.Add("@name", SqlDbType.VarChar,30 );
        myCmd.Parameters.Add("@pass", SqlDbType.VarChar,200 );
        _playerCheckCmd=myCmd;
    }
    //.....
    int CheckPlayer(string someUserName, string someAlreadyHashedString)
    {
        var connectionString=Properties.Settings.Default.MyConnectionString;
        using(var myConn= new MySqlConnection(connectionString))
        {
            _playerCheckCmd.Connection=myConn;
            _playerCheckCmd.Parameters["@name"].Value=someUserName;
            _playerCheckCmd.Parameters["@pass"].Value=someAlreadyHashedString;
            myConn.Open();
            var result=_playerCheckCmd.ExecuteScalar();
            return result;
        }
    }
