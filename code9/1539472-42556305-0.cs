    public void execSqlRead(String req)
    {  
        this.OpenConnection();
        MySqlCommand cmd = this.connectionBDD.CreateCommand();
        cmd.CommandText = req;
        MySqlDataReader myReader;
        myReader= cmd.ExecuteReader();  //stop here
        try
        {
            while (myReader.Read())
            {
                Console.WriteLine(myReader.GetString(0));
            }
        }
        finally
        {
            Console.WriteLine("Yolo");
            this.deconnexion();
        }
        //return myReader;
    }
