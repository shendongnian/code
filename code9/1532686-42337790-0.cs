    public string Login(string Username, string Password)
    {
        String result;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Nicole Wong\Desktop\Inari Tracking System\Inari Tracking System\App_Data\Database1.mdf;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT Username, Password from UserData where Username = @Username AND Password = @Password", con);
        cmd.Parameters.AddWithValue("@UserName", Username);
        cmd.Parameters.AddWithValue("@Password", Password);
        //This us pretty much useless on a select, SELECT is a query, not a NonQuery
        //cmd.ExecuteNonQuery(); 
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        // Create an instance of DataSet.
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count> 0)
        {
            DateTime dt = DateTime.Now;
            SqlCommand cmd1 = new SqlCommand("INSERT INTO ActivityLog (CreateOn, CreateBy) VALUES (@CreateOn,@CreateBy)", con);
            cmd1.Parameters.AddWithValue("@CreateOn", dt);
            cmd1.Parameters.AddWithValue("@CreateBy", Username);
            cmd1.ExecuteNonQuery();
            //Don't use the DataAdapter and try to fill a dataset from an insert, all this insert will return is @@ROWCOUNT
            //SqlDataAdapter da1 = new SqlDataAdapter(cmd1); 
            // Create an instance of DataSet.
            //DataSet ds1 = new DataSet();
            //da1.Fill(ds); 
            con.Close();
            result = "Successful";
            return result;
        }
        else
        {
            result = "Fail";
            return result;
        }
