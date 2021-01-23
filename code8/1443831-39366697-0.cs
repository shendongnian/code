    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = info(id);
        GridView1.DataBind();
    }
    or 
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = info(id);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
