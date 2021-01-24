    MySqlConnection con = new MySqlConnection(WebConfigurationManager.ConnectionStrings["con3"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
        
            string s = "select distinct IMEI_NO FROM permission";
            MySqlDataAdapter ad = new MySqlDataAdapter(s, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ddl1.DataSource = dt;
            ddl1.DataTextField = "IMEI_NO";
            ddl1.DataValueField = "IMEI_NO";
            ddl1.DataBind();
            }
 
    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string s = "select distinct CA_NO FROM permission WHERE IMEI_NO='"+ddl1.SelectedItem+"'";
            MySqlCommand cmd = new MySqlCommand(s, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            ddl2.DataSource = dt;
            ddl2.DataTextField = "CA_NO";
            ddl2.DataValueField = "CA_NO";
            ddl2.DataBind();
        }
