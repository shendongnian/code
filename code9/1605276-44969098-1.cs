    protected void Page_Load(object sender, EventArgs e)
        {
            FillDropDown();
            if (!string.IsNullOrEmpty(Request.QueryString["selectedReg"]))
            {
                string selectedReg = Request.QueryString["selectedReg"];
                ddlVehicleReg.SelectedIndex = ddlVehicleReg.Items.IndexOf(ddlVehicleReg.Items.FindByText(selectedReg));
            }
        }
       protected void FillDropDown()
        {
            using (SqlConnection con= new SqlConnection("server=.;database=StackTest;integrated security=true") )
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from Test", con);
                DataTable dt = new DataTable("Test");
                adp.Fill(dt);
                ddlVehicleReg.DataValueField = "Id";
                ddlVehicleReg.DataTextField = "Value";
                ddlVehicleReg.DataSource = dt;
                ddlVehicleReg.DataBind();
            }
        }
