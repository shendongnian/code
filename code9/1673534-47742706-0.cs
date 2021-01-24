    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into funtable values('"+txtname.Text+"','"+txtcity.Text+"')";
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("display.aspx");
    }
