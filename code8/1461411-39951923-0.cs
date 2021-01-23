    string query= "SELECT * FROM Members where Username= 'usr' and Password= 'pwd'";
        SqlCommand cmd = new SqlCommand(query, con);
        MySqlDataAdapter objda = new MySqlDataAdapter(cmd);
        DataSet objDs = new DataSet();
        objda.Fill(objDs);
        if(objDs.Tables[0].Rows.Count>0)
        {
              Response.Write("Sign in successful");
              Response.Redirect("MemberTestPage.aspx");
        }
