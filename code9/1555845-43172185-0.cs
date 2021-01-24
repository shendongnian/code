    string ConString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(ConString))
    {
        SqlCommand cmd = new SqlCommand("SELECT roll, tc, tf, pc, pf FROM cmt_7th WHERE name IS Null And department IS Null And phone IS Null", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable("cmt_7th");
        sda.Fill(dt);
        MydataGrid_roll.AutoGenerateColumns = false;
        MydataGrid_roll.Columns.Add(new DataGridTextColumn() { Header = "roll", Binding = new Binding("roll") });
        MydataGrid_roll.ItemsSource = dt.DefaultView;
    }
