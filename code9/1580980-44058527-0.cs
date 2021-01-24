    string cs = ConfigurationManager.ConnectionStrings["CHTproductionConnectionString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(cs))
    {
        SqlDataAdapter Adapter = new SqlDataAdapter();
        DataSet TempData = new DataSet();
        SqlCommand cmd = new SqlCommand("spGetImageId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter paramID = new SqlParameter()
        {
            ParameterName = "@Id",
           Value = Request.QueryString["ID"]
        };
        cmd.Parameters.Add(paramID);
        con.Open();
        Adapter.SelectCommand = cmd;
        Adapter.Fill(TempData);
        string title = TempData.Tables[0].Rows[0]["title"].ToString();
        string description = TempData.Tables[0].Rows[0]["description"].ToString();
        string imageBytes = TempData.Tables[0].Rows[0]["imageData"].ToString();
        string strBase64 = Convert.ToBase64String(imageBytes );
        Image1.ImageUrl = "data:Image/png;base64," + strBase64;
    }
