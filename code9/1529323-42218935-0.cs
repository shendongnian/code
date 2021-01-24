     if (reader != null && reader.HasRows)
            {
                newpass.Visible = true;
                confpass.Visible = true;
                Label1.Text = "New Password";
                Label2.Text = "Confirm New Password";
                SqlDataAdapter updates = new SqlDataAdapter("update reg set Password='" + newpass.Text + "'", con);
                DataSet ds = new DataSet();
                updates.Fill(ds);
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('The Password has been Changed')</script>");
                con.Close();
            }
