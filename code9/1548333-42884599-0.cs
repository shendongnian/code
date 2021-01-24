    using(SqlDataAdapter da = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        da.SelectCommand = cmd;
    
                        DataTable dt = new DataTable();
                        da.Fill(dt);                      
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
    
                    }
