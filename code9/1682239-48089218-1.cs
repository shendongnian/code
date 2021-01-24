            DataTable dr = new DataTable();
            string email = txtEmail.Text;
            SqlConnection con = new SqlConnection(Ws.Con);
            con.Open();
            int s = Convert.ToInt32(add.Text);
            SqlCommand cmd = new SqlCommand("Update [Order] set  Balance=Balance+'" + s + "',Card='" + card.Text + "' where email=@email ", con);
            cmd.Parameters.AddWithValue("email", email);
            //Create a new SqlComamnd
            SqlCommand selectCommand = new SqlCommand("Select * from [Order]");
            //Put the newly created instance as SelectCommand for your SqlDataAdapter
            SqlDataAdapter sda = new SqlDataAdapter(selectCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int i = cmd.ExecuteNonQuery();
            con.Close();
