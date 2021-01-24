    void InitializeCommands()
    {
        var query = "Select Gender from UserDetails d " +
                    " inner Join Users on Users.UserId=d.UserID " + 
                    " where UserName=@user";
   
        _genderCmd=new SqlCommand(query);
        _genderCmd.Parameters.Add("@user",SqlDbType.NVarChar,30);
    }
    //....
    public string GetGender(string user)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            genderCmd.Connection=con;
            genderCmd.Parameters["@user"].Value=user;
            var gender=(string)genderCmd.ExecuteScalar();
            return gender;
        }
    }
