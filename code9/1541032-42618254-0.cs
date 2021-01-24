      protected void Button1_Click(object sender, EventArgs e) {
        if (temp == 0) {
         try {
          SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
          conn.Open();
    
          string insertquery = "insert into [Table] (Designation, Username, Email, [Password]) values (@Designation, @Username, @Email, @Password)";
    
          SqlCommand com = new SqlCommand(insertquery, conn);
    
          com.Parameters.Add("@Designation", SqlDbType.VarChar).Value = dn.SelectedItem.ToString();
          com.Parameters.Add("@Username", SqlDbType.VarChar).Value = un.Text;
          com.Parameters.Add("@Email", SqlDbType.VarChar).Value = em.Text;
          com.Parameters.Add("@Password", SqlDbType.VarChar).Value = pw.Text;
          com.ExecuteNonQuery();
          Response.Redirect("Managers.aspx");
          Response.Write("Registration Successful");
          conn.Close();
         } catch (Exception ex) {
          Response.Write("error :" + ex.ToString());
         }
        }
       }
