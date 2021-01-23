    Method 1:Using Simple Sql Querry
     public void Update(Int UserId,String UserName  )
    {
        SqlConnection con = new SqlConnection("Your Connection String");  
        con.Open();  
        string str = " UPDATE [dbo].[User] SET [UserName] = "+UserName  +" WHERE   [UserId] ="+ UserId+"";
        SqlCommand cmd = new SqlCommand(str , con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    Method 2:Using Stored Procedure   
    First execute Your Stored Procedure in database,   
    Example   
    CREATE PROCEDURE [dbo].[UpdateUser]   
    @UserId int,   
    @UserName varchar(25)   
    AS   
    BEGIN   
    UPDATE [dbo].[User] SET [UserName] = @UserName WHERE [UserId] = @UserId   
    END   
    
     public void Update(Int UserId,String UserName  )
    { 
 
        SqlConnection con = new SqlConnection("Your Connection String");  
        con.Open();
        SqlCommand cmd = new SqlCommand("UpdateUser", con); //UpdateUser is the name of stored procedure you created
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("UserName ", UserName );
        cmd.Parameters.AddWithValue("UserId", UserId);
        cmd.ExecuteNonQuery();
        con.Close();
       
     }
