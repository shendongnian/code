    protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Populateddl1();
            }
        }
        private void Populateddl1()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            string selectmap = "select [id]+' - '+[title] as title, id from map order by id;";
            SqlDataAdapter comm = new SqlDataAdapter(selectmap, conn);
            DataTable dt = new DataTable();
            comm.Fill(dt);
            conn.Close();
            ddl1.DataSource = dt;
            ddl1.DataTextField = "title";
            ddl1.DataValueField = "id";
            ddl1.DataBind();
            ddl1.Items.Insert(0, new ListItem("---- Select Map ----", "0"));
           
        }
        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Write here for populating second dropdown code
        }
