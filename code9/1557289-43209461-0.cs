    SqlConnection con = new SqlConnection(@"Data Source=
        (LocalDB)\MSSQLLocalDB;AttachDbFilename=
        C:\WpfApplication\Database.mdf;Integrated Security=True");
    con.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
    con.Open();
    
    SqlCommand cmd = new SqlCommand();
    cmd.CommandText = "UPDATE [People] SET [Number] = [Number] + @nm WHERE [Name] = @Name;";
    cmd.Parameters.Add("@nm", SqlDbType.Int).Value = 0;
    cmd.Connection = con;
    cmd.ExecuteNonQuery();
