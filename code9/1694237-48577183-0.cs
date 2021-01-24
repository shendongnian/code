       string constr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("update Student set Name='" + Name.Text + "',Address='" + Address.Text + "'where RegNo=" + RegNo.Text);
              
                cmd.Connection = con;//adding this line my error solved
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                
