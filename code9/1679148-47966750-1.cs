     protected void Button1_Click(object sender, EventArgs e)
            {
                string sql = "";
                SqlConnection cn = null;
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                string User = username.Text;
                string Pwd = passwd.Text;
                //cn = "<< your connection string>>";
                try
                {
                    cn.Open();
                    // Your code
    
                    sql = "EXEC dbo.sProc_Admin_Auth @UserNm = '" + User + "',@Pwd = '" + Pwd + "'";
    
                    cmd = new SqlCommand(sql, cn);
    
                    dr = cmd.ExecuteReader();
    
                    if (dr.Read())
                    {
                        Session["UserId"] = dr["UserId"].ToString();
                        Session["LoginId"] = User;
                        Session["UserNm"] = dr["FullNm"].ToString();// "Jayasurya Satheesh";
                        Session["Email"] = dr["Email"].ToString();
                        Session["JoinDt"] = dr["CreateDt"].ToString();
                        Response.Redirect("Index.aspx");
                        LblError.Visible = false;
                    }
                    else
                    {
                        LblError.Visible = true;
                        LblError.Text = "Login Failed!";
                    }
                }
                catch (Exception exce)
                {
                    LblError.Text = exce.Message;
                }
                finally
                {
                    cn.Close();
                }
            }
