    //Using Output parameter
    String strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
    SqlConnection con = new SqlConnection(strConnString);
    SqlCommand cmd = new SqlCommand();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "AddEmployeeReturnIDwithoutput";
    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text.Trim();
    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text.Trim();
    cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = txtBirthDate.Text.Trim();
    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = txtCity.Text.Trim();
    cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text.Trim();
    cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;    
    cmd.Connection = con;
    try
    {
        con.Open();
        cmd.ExecuteNonQuery() ;
        string id = cmd.Parameters["@id"].Value.ToString() ;
        lblMessage.Text = "Record inserted successfully. ID = " +  id;
    }
    catch (Exception ex)
    {
        throw ex;
    }
    finally
    {
        con.Close();
        con.Dispose();
    }
