    using (var con = new SqlConnection(ConfigurationManager.AppSettings["db"]))
    {
        con.Open();
        var sql = "/* My command here */";
        using (var cmd = new SqlCommand(sql, con))
        {
            // SQL execution here
        }
    } // Closing is now handled for you (even if errors occur)
