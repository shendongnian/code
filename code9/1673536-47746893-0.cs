        protected void btnsubmit_Click(object sender, EventArgs e)
        {
        }
        static int did;
        protected void ddlupdate_SelectedIndexChange
        {
            did = int.Parse(ddlupdate.SelectedValue);
            SqlConnection con = new SqlConnection(@"");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select firstname, lastname, email, 
           gender, role, phoneno, filename from tbldata where Id=" +did, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtname.Text = dr.GetString(0);
                txtlastname.Text = dr.GetString(1);
                txtemail.Text = dr.GetString(2);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string fname, lastname, email, gender, role, phoneno, filename;
            fname = txtname.Text;
            lastname = txtlastname.Text;
            email = txtemail.Text;
            gender = Rbgender.SelectedValue;
            phoneno = txtphno.Text;
            role = DropDownList1.SelectedValue;
            filename = System.IO.Path.GetFileName(Fupload.FileName);
            Fupload.SaveAs(Server.MapPath("Uploads/") + filename);
            SqlConnection con = new SqlConnection(@"");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update tbldata set firstname=@fname,lastname=@lastname,email=@email,gender=@gender,role=@role,phoneno=@phoneno,filename=@filename where id=@did", con);
            cmd.Parameters.AddWithValue("@firstanme", fname);
            con.Close();
       }
    }
   }
