    private bool DoesEmailExist(string email)
    {
        var conStr = @"putYourConnectionStringHere";
        var q = "select TOP 1 Name from Client WHERE Name=@name";
        using (var c =new SqlConnection(conStr))
        {
           using (var cmd = new SqlCommand(q, c))
           {
                c.Open();
                cmd.Parameters.AddWithValue("@email", email);
                var r = cmd.ExecuteReader();
                return r.HasRows;
           }
        }
    }
