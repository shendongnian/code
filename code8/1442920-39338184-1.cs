    public static string GetContactName(string custid)
        {
        if (custid == null || custid.Length == 0)
            return String.Empty;
        SqlConnection conn = null;
        try
        {
            string connection = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            conn = new SqlConnection(connection);
            string sql = "Select ContactName from Customers where CustomerId = @CustID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("CustID", custid);
            conn.Open();
            string contNm = Convert.ToString(cmd.ExecuteScalar());
            return contNm;
        }
        catch (SqlException ex)
        {
            return "error";
        }
        finally
        {
            conn.Close();
        }
    }
