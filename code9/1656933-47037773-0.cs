    using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        using(var com = new SqlCommand("insert into sanctuary(SName) values('test');insert into species(Name) values('test1');insert into species(Name) values('test1');", con)
        {
             con.Open();
             com.ExecuteNonQuery();
        }
    }
