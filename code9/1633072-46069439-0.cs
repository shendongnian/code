    var connetionString = "Data Source=EVOPC18\\PMSMART;Initial Catalog=NORTHWND;User ID=test;Password=test";
    var sql = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Title = @Title ... ";// repeat for all variables
    try
    {
        using(var connection = new SqlConnection(connetionString))
        {
            using(var command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = Lnamestring;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = Fnamestring;
                command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Titelstring;
                // repeat for all variables....
                connection.Open();
                command.ExecuteNonQuery();
            }       
        }
    }
    catch (Exception e)
    {
        MessageBox.Show($"Failed to update. Error message: {e.Message}");
    }
