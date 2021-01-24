    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlProvince.DataSource = sqlDsProvince;
            ddlProvince.DataTextField = "ProvinceName";
            ddlProvince.DataValueField = "ProvinceID";
            ddlProvince.DataBind(); // don't forget to add this for binding dropdownlist items
        }
    }
