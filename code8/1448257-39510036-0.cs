    protected void sendbtnSubmit(object sender,EventArgs e)
                {
         string connectionString = "Server=KSRSAC-G2G\\SQLEXPRESS;Database=Registration;Uid=sa;Pwd=SA#123;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [Registration].[dbo].[FeedBack] (Name,Emailid,Category,Feedback,Area,Rate) VALUES (@Name, @Emailid,@Category,@Feedback,@Area,@Rate)");
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@Name", name.Text);
                        cmd.Parameters.AddWithValue("@Emailid", email.Text);
                        cmd.Parameters.AddWithValue("@Category", cate.Text);
                        cmd.Parameters.AddWithValue("@Feedback", msg.Text);
                        cmd.Parameters.AddWithValue("@Area", ddlfields.Text);
                        cmd.Parameters.AddWithValue("@Rate", e.Value.ToString());
                        connection.Open();
                        cmd.ExecuteNonQuery();
             }
        }
        protected void Rating1_Changed(object sender, EventArgs e)
                {
                    lbl_point.Text = "You rated " + e.Value.ToString();
                }
    
            }
