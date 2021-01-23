    private void Form2_Load(object sender, EventArgs e)
    {
        string txt=textBox1.Text;
        DataSet ds = new DataSet();
        ds=db.getDataQuery(txt);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }     
       
