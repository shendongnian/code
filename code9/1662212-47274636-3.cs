    void Page_Load(object sender, EventArgs e)
    {
        var username = new SqlParameter("@Username", SqlDbType.Int);
        username.Value = Request.QueryString("ID");
        
        byte[] bytes = (byte[])GetData("SELECT Image FROM SI WHERE  Username= @Username", username).Rows[0]["Image"];
        Response.BinaryWrite(bytes);
    }
