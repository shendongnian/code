    [WebMethod]
    public static string Insert_Data(string user, string pwd)
    {   
                sql = "EXEC dbo.sProc_Admin_Auth @UserNm = '" + User + "',@Pwd = '"+Pwd+"'";
                cmd = new SqlCommand(sql, cn.connect());
                dr = cmd.ExecuteReader();
                if(dr.Read())
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
