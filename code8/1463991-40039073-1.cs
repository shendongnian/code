        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView1.RowCommand -= GridView1_RowCommand;
            if (e.CommandName.Equals("Insert"))
            {
                TextBox name = (TextBox)GridView1.FooterRow.FindControl("TextBox1");
                TextBox lname = (TextBox)GridView1.FooterRow.FindControl("txtlname");
                TextBox age = (TextBox)GridView1.FooterRow.FindControl("txtlage");
                DropDownList isactive = (DropDownList)GridView1.FooterRow.FindControl("ddlactive");
                using(SqlConnection conn = new SqlConnection(_connStr))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO PersonalDetail(FirstName,LastName,Age,Active) VALUES('" + name.Text + "','" + lname.Text + "','" + age.Text + "','" + isactive.SelectedItem.Value + "')",conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //int result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            lblMessage.Text =
            "Record has been Added successfully !";
            this.PopulateData();
            
        }
