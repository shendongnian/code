    using (var conn = new SqlConnection(sqlConString))
    {
        using(var insertQuery = new SqlCommand("INSERT INTO user_table (Username, Password, Name, Surname, DOB) VALUES ( @Username, @Password, @Name, @Surname, @DOB)", conn))
        {
            // I'm assuming nvarcar as the data type, change it if needed....
            insertQuery.Parameters.Add("@Username", SqlDbType.NVarChar).Value = edtUsername.Text;
            insertQuery.Parameters.Add("@Password", SqlDbType.NVarChar).Value = HashPassword(edtPassword.Text); 
            insertQuery.Parameters.Add("@Name", SqlDbType.NVarChar).Value = edtName.Text;
            insertQuery.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = edtSurname.Text;
            insertQuery.Parameters.Add("@DOB", SqlDbType.DateTime).Value = dateTimePicker.Value;
            conn.Open();
            insertQuery.ExecuteNonQuery();
        }
    } 
    
    string HashPassword(string password)
    {
        // TODO: Implement hashing with salt
    }
