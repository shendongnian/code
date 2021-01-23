     protected void Button1_Click(object sender, EventArgs e)
    {
        string find = "select * from PRODUCT where PRODUCT_NAME like @PRODUCT_NAME";
        SqlCommand comm = new SqlCommand(find, con);
        comm.Parameters.Add("@PRODUCT_NAME", SqlDbType.NVarChar).Value = "%"+ SearchBox.Text + "%";
        SqlDataAdapter da = new SqlDataAdapter(comm);
        DataSet ds = new DataSet();
        da.Fill(ds, "PRODUCT_NAME");
        GridView2.DataSource = ds.Tables[0];
        GridView2.DataBind();
    
    }
