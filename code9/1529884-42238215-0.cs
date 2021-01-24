    if (reader != null &&  reader.HasRows)
    {
        Label3.Text = reader.GetString("Security1");
        Label4.Text = reader.GetString("Security2");
        newpass.Visible = true;
        confpass.Visible = true;
        Label1.Text = "New Password";
        Label2.Text = "Confirm New Password";
        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        cons.Open();
        SqlCommand updates = new SqlCommand("update reg set Password='" + confpass.Text + "'", cons);
        SqlDataAdapter da = new SqlDataAdapter(updates);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        cons.Close();
        //ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Your password has been changed')</script>");
               // Response.Redirect("Default.aspx");
    }
