      public void LoadData()
            {
                DataTable dt = new DataTable();
                using (var conn = new SqlConnection("your connection string here"))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                     
                        //set the command up as a select
                        cmd.CommandText = "select tbl_user.id,tbl_user.name,tbl_user.family, sum(tbl_price.price) "+
                        "from tbl_user, tbl_price " +
                        "where tbl_user.id = tbl_price.user_id_fk " +
                        "group by tbl_user.name + '' + tbl_user.family,tbl_user.id,tbl_user.name,tbl_user.family";
    
                        using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                        {
                            a.Fill(dt);
                        }
    
                        //set the datasource of the gridview to the loaded table.  The gridview will now display the data of your select statement.
                        dgvActivity.DataSource = dt;
    
                    }
                }
            }
