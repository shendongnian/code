    public ActionResult Index()
    {
        List<string> result = new List<string>();
        string constr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        string query = "SELECT top 10 Keys FROM dbo.TestTable";
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while(reader.Read())
                {
                      result.Add(reader[0].ToString());
                }
            }
            finally
            {
                reader.Close();
            }
    }
        return View(result);
    }
