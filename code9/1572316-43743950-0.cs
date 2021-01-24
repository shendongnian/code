		protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=testingDB;User id=sqluser2;Password=password01;"))
            {
                SqlCommand command1 = new SqlCommand("UPDATE Bruger SET Name=@Fornavn where Email=@email;",con);
                //SqlCommand command1 = new SqlCommand();
                //command1 = con.CreateCommand();
                //command1.CommandText = "UPDATE Bruger set fornavn='"  + txtFornavn.Text+ "' where email='" + Session["email"] + "';";
                command1.Parameters.AddWithValue("@Fornavn", txtFornavn.Text);
				command1.Parameters.AddWithValue("@email", Session["Email"]);
                command1.Connection.Open();
                command1.ExecuteNonQuery();
                con.Close();
		}
