    public void InsertRegistration(Registration.Registration reg)
    {
        try
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
            {
                using (var cmd = new SqlCommand("dbo.Procedure", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var parameterName = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                    parameterName.Value = reg.Name;
                    var parameterAge = new SqlParameter("@Age", SqlDbType.VarChar, 50);
                    parameterAge.Value = reg.Age;
                    var parameterSex = new SqlParameter("@Sex", SqlDbType.VarChar, 50);
                    parameterSex.Value = reg.Sex;
                    var parameterAddress = new SqlParameter("@Address", SqlDbType.VarChar, 50);
                    parameterAddress.Value = reg.Address;
                    var parameterEmail = new SqlParameter("@Email", SqlDbType.VarChar, 100);
                    parameterEmail.Value = reg.Email;
                    var parameterPhone = new SqlParameter("@Phone", SqlDbType.VarChar, 100);
                    parameterPhone.Value = reg.Phone;
                    cmd.Parameters.Add(parameterName);
                    cmd.Parameters.Add(parameterAge);
                    cmd.Parameters.Add(parameterSex);
                    cmd.Parameters.Add(parameterAddress);
                    cmd.Parameters.Add(parameterEmail);
                    cmd.Parameters.Add(parameterPhone);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
