        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //populating ddlGroupName DropDown
                ddlGroupName.DataSource = transMedHandler.GetGroupNames();
                ddlGroupName.DataTextField = "GroupName";
                ddlGroupName.DataValueField = "Id";
                ddlGroupName.DataBind();
                ddlGroupName.SelectedIndex = 0;
                //populating ddlStatus DropDown
                ddlStatus.DataSource = transMedHandler.GetNames();
                ddlStatus.DataTextField = "GroupName";
                ddlStatus.DataValueField = "Id";
                ddlStatus.DataBind();
                ddlStatus.SelectedIndex = 0;
            }
        }
        protected void GetGroupNames() 
        {
            gv1.DataSource = transMedHandler.GetGroupNames();
            gv1.DataBind(); 
        }
        protected void GetNames()
        {
            gv1.DataSource = transMedHandler.GetNames();
            gv1.DataBind();
        }
        protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroupNames(); 
        }
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNames();
        }
