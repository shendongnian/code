     string connetionString = null;
            SqlConnection cnn ;
            SqlCommand cmd ;
            string sql = null;
            connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            sql = "Your SQL Statemnt Here";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                MessageBox.Show (" ExecuteNonQuery in SqlCommand executed !!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
