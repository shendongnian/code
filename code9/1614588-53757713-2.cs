    public ActionResult MyResult()
        {
            string userid = User.Identity.GetUserId();
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("My_Result", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    DataSet ds = new DataSet();
                    SqlParameter[] prms = new SqlParameter[1];
                    prms[0] = new SqlParameter("@Userid", SqlDbType.VarChar, 500);
                    prms[0].Value = userid;
                    cmd.Parameters.AddRange(prms);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(ds);
                    conn.Close();
                
            
                    return View(ds);
                }
            }
          }
