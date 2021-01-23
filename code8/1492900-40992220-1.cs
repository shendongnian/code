    if (Page.IsPostBack)
    {
        SqlConnection conn = new SqlConnection("Data Source=FATIMAH;Initial Catalog=Bank database;Integrated Security=True");
        String sql;
        sql = "delete FROM Account where number ='" + DropDownList3.SelectedValue +"'";
        SqlCommand comm = new SqlCommand(sql, conn);
        comm.ExecuteNonQuery() 
        conn.Close();
    }
