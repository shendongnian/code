    protected void Page_Load(object sender, EventArgs e)
    {
        SqlParameter[] parameters = new SqlParameter[1];
        parameters[0] = new SqlParameter("@Id", SqlDbType.Int) { Value = Convert.ToInt32(Request.QueryString["ID"]) };
        DataTable dt = this.GetDataTableFromSproc("spGetImageId", parameters);
        string title = dt.Rows[0]["title"].ToString();
        string description = dt.Rows[0]["description"].ToString();
        Image1.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["imageData"]);
    }
