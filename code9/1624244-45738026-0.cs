    const string sql = "select description from dbo.workcategory where workcategoryid = 3";
    var connectionString = ConfigurationManager.ConnectionStrings["SpectrumContext"].ConnectionString;
    using (var cn = new SqlConnection(connectionString))
    {
        using (var cmd = new SqlCommand(sql, cn))
        {
            var results = Convert.ToString(cmd.ExecuteScalar());
                        
            return View(results);
         }
    }
