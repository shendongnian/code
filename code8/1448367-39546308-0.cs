    using (con = new SqlConnection(con_str))
    {
        con.Open();
        string sql = "select mcfact as Factory, mcarea as Department, mcloc as Location, mcroom as Room, mcline as Line, CONVERT(VARCHAR(10),scanned,120) from tb_MachineRecord where mcidno='" + cmbmcidno.Text + "' ";
        da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView7.DataSource = ds;
        GridView7.DataBind();
        con.Close();
    }
