     protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT su.SupplierID, su.Status, ut.Username, ut.Password, ut.UserID FROM UserTable ut INNER JOIN Suppliers su ON su.UserID = ut.UserID Where ut.Username = '" + txtUsername.Text + "' AND ut.Password = '" + Helper.CreateSHAHash(txtPassword.Text) + "'", con);
    
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["SupplierID"] = dr["SupplierID"].ToString();
                        Session["Status"] = dr["Status"].ToString();
                        Session["Username"] = dr["Username"].ToString();
                        Session["UserID"] = dr["UserID"].ToString();
                    }
    
                    string statuscode = Session["Status"].ToString();
    
    
                    switch (statuscode)
                    {
                        case "Active":
                            Session["Status"] = null;
                            Session.Remove("Status");
                            Response.Redirect("\\Account\\Suppliers\\Default.aspx");
                            break;
    
                        case "Inactive":
    
                            lblsource.Text = "Login Page: INACTIVE";
                            lblmessage.Text = "Welcome Back! Please let us know on how we can help you better.";
                            
                            break;
    
                        case "Pending":
                            lblsource.Text = "Login Page: PENDING";
                            lblmessage.Text = "Thank you for registering with us. We will process your request shortly.";
                            lblsource.Visible = true;
                            lblmessage.Visible = true;
    
                            
                            break;
    
                        case "Blocked":
                            lblsource.Text = "Login Page: BLOCKED";
                            lblmessage.Text = "We are so glad to hear from you. Please settle your account.";
                            lblsource.Visible = true;
                            lblmessage.Visible = true;
                            
                            break;
                    }
    
                }
                else
                {
                    Label1.Visible = true;
                }
    
    
    
    
        }
