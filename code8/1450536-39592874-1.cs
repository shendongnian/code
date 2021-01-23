    public void Update(Int UserId,String UserName  )
    {
        SqlConnection con = new SqlConnection("Your Connection String");  
        con.Open();  
        string str = " UPDATE [dbo].[User] SET [UserName] = "+UserName  +" WHERE   [UserId] ="+ UserId+"";
        SqlCommand cmd = new SqlCommand(str , con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
