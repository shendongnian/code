    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Napster\Documents\Visual Studio 2015\WebSites\Webdemo\App_Data\demodatabase.mdf;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        con.Open();
       SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "insert into demotable values('" + txtname.Text + "','" + txtcity.Text + "')";
       cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("default.aspx");
        
    }
}
