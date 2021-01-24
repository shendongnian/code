       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCity();
                if (DropDownListCity.Items != null)
                {                    
                    GetTown(Convert.ToInt32(DropDownListCity.SelectedValue.ToString()));
                }
            }
        }
        private void GetCity()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["aytasarimConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT * FROM tbl_City order by cityName", conn);
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
        
        private void GetTown(Int32  selectedCityNo)
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
                comm = new SqlCommand("SELECT * FROM tbl_Town WHERE cityno='" + selectedCityNo.ToString() + "' order by townname", conn);
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
                    Response.Write(message);
                }
                
            }
        }
        protected void DropDownListCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCity = (DropDownList)sender;
            string selectedID = ddlCity.ID;
            DropDownList ddlSelectedCity = (DropDownList)FindControl(selectedID);
            GetTown(Convert.ToInt32(ddlSelectedCity.SelectedValue.ToString()));
        }
