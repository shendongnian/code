    [WebMethod]
    public static string GetCustomers()
    {
        string query = "SELECT top 10 CustomerID, ContactName, City FROM Customers";
        SqlCommand cmd = new SqlCommand(query);
        return GetData(cmd).GetXml();
    }
    private static DataSet GetData(SqlCommand cmd)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
     
                }
            }
        }
    }
