    public void AddGebruiker()
    {
            string query = "insert into Gebruiker VALUES(3, 'Cihan', 'Kurt', 18, 'Man', 85, 75, 'Admin1', 'Test123', 'testen');";
            using (SqlConnection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int resultaat = command.ExecuteNonQuery();
                    if (resultaat == 1)
                    {
                        MessageBox.Show("succes");
                    }
                    else
                    {
                        MessageBox.Show("fail");
                    }
                }
            }
        }
