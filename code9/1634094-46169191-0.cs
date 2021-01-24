      protected void submit_Click(object sender, EventArgs e)
    {
        
        BindGrid();
    }
    protected void BindGrid()
    
 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data source= LAPTOP-6\\SQLEXPRESS;Initial Catalog=training;integrated Security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Sp_PO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            try
            {
                con.Open();
                GridView1.EmptyDataText = "No Records Found";
                
                 DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                GridView1.DataSource = ds;
                GridView1.DataBind();
                }
