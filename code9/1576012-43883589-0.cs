    SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=....;Integrated Security=True;Connect Timeout=30;User Instance=True;");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader dtr;
    protected void Page_Load(object sender, EventArgs e)
    {
        cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = "select BicycleType from TourDisplay order by TDateTime asc";
        dtr = cmd.ExecuteReader();
        bool temp = false;
        while (dtr.Read())
        {
            TBBicycleType.Text = dtr.GetString(0);
            temp = true;
        }     
    }
