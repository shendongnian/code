               con.Open();
               SqlCommand cmd = new SqlCommand("Select * from Register", con);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                 con.Close();
                 if (ds.Tables[0].Rows.Count > 0)
                 {
                    Gridview1.DataSource = ds;
                   Gridview1.DataBind();
                   UpdatePanel1.Update();
                  }
