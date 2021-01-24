                protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCity();
                GetTown(int.Parse(DropDownListCity.SelectedItem.ToString()));                
            }
        }
        private void GetCity()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["aytasarimConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT * FROM tbl_City", conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                DropDownListCity.DataSource = reader;
                DropDownListCity.DataValueField = "cityno";
                DropDownListCity.DataTextField = "cityname";
                DropDownListCity.DataBind();
                reader.Close();
            }
            catch
            {
                string message = "<script>alert('Error!');</script>";
                Response.Write(message);
            }
            
        }
        
        private void GetTown(int selectedCityNo)
        {
            if (selectedCityNo == 0)
            {
                DropDownListTown.Visible = false;
            }
            else
            {
                SqlConnection conn;
                SqlCommand comm;
                SqlDataReader reader;
                string connectionString = ConfigurationManager.ConnectionStrings["aytasarimConnectionString"].ConnectionString;
                conn = new SqlConnection(connectionString);
                comm = new SqlCommand("SELECT * FROM tbl_Town WHERE cityno='" + selectedCityNo.ToString() + "'", conn);
                try
                {
                    conn.Open();
                    reader = comm.ExecuteReader();
                    DropDownListTown.DataSource = reader;
                    DropDownListTown.DataValueField = "townno";
                    DropDownListTown.DataTextField = "townname";
                    DropDownListTown.DataBind();
                    reader.Close();
                }
                catch
                {
                    string message = "<script>alert('Error!');</script>";
                    Response.Write(mesaj);
                }
                
            }
        }
        protected void DropDownListCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCity = (DropDownList)sender;
            string selectedID = ddlCity.ID;
            DropDownList ddlSelectedCity = (DropDownList)FindControl(selectedID);
            GetTown(int.Parse(ddlSelectedCity.SelectedItem.ToString()));
        }
