    protected void lnkInsert_Click(object sender, EventArgs e)
    {
        string strsql = DBConnection.sqlstr;
        //create object for sqlconnection
        SqlConnection sqlcon = new SqlConnection(strsql);
        //here i use the query
        string strQuery = "Insert into [User] (UserName,Address1,EmailAddress) values (@UserName,@Address1,@EmailAddress)";
        //create the object of sqlcommand
        SqlCommand sqlcmd = new SqlCommand(strQuery, sqlcon);
        //find the footer row for UserName And Assign the value
        sqlcmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = ((TextBox)GridView1.FooterRow.FindControl("txtfooterUserName")).Text;
        sqlcmd.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = ((TextBox)GridView1.FooterRow.FindControl("txtfooterAddress1")).Text;
        sqlcmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = ((TextBox)GridView1.FooterRow.FindControl("txtfooterEmailAddress")).Text;
        //open the sql connection
        sqlcon.Open();
        // Execute the Insert Command In to Database
        sqlcmd.ExecuteNonQuery();
        //close the sqlconnection
        sqlcon.Close();
        //if record successfully insert we display the message
        lblMessage.Visible = true;
        //bind grid view for latest record
        BindGridView();
    }
