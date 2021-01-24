    [System.Web.Services.WebMethod]
    public static bool CheckDB(String DBConnection)
    {
        try
        {
            using(var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DBConnection].ConnectionString);
            {
                con.Open();
                return true;
            }
        }
        catch
        {
            return false;
        }
     }
