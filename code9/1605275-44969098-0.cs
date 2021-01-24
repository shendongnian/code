    protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["selectedReg"]))
            {
                string selectedReg = Request.QueryString["selectedReg"];
                ddlVehicleReg.SelectedIndex = ddlVehicleReg.Items.IndexOf(ddlVehicleReg.Items.FindByText(selectedReg));
            }
        }
    enter code here
