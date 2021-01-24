    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    SqlConnection con = new SqlConnection(constr);
    con.Open();
    SqlCommand cmd = new SqlCommand("select bookingId, bookingName, fprice from addCart");
    SqlDataAdapter sda = new SqlDataAdapter();
    cmd.Connection = con;
    sda.SelectCommand = cmd;
             using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            //decode the bookingid and bookingname and update in table
                           if(dr["bookingName"].ToString()!=""){
                            string newbookingname = System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(dr["bookingName"].ToString()));
                          
                            dr["bookingName"] = newbookingname;
                           }
                        }
                        
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
    con.Close();  
