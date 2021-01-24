    private void buttoninloggen_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connectionstring))
        {
            connection.Open();
            string emailinlog = textBoxEmailLogin.Text;
            string passwordinlog = textBoxPasswordLogin.Text;
            string vergelijken = "select * from Account where Email = @email and Password = @password";
            // Moved the 'SqlDataAdapter' further down
            // SqlDataAdapter adapter = new SqlDataAdapter(vergelijken, connection);
            MessageBox.Show("tot hier is t goed");
            using (SqlCommand ophalen = new SqlCommand(vergelijken, connection))
            {
                ophalen.Parameters.AddWithValue("@email", emailinlog);
                ophalen.Parameters.AddWithValue("@password", passwordinlog);
                DataTable tafel = new DataTable();
                // SqlDataAdapter is now here
                // As it has been passed the SqlCommand it understands the parameters
                // Wrapped in using statement for disposal
                using (SqlDataAdapter adapter = new SqlDataAdapter(ophalen))
                {
                    adapter.Fill(tafel);
                    if (tafel.Rows.Count > 0)
                    {
                        MessageBox.Show("ingelogd");
                    }
                }
            }
        }
    }
