    MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT number FROM numbers ORDER BY RAND() LIMIT 2; ";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                HtmlLabel[] labels = new HtmlLabel[] { htmlLabel1, htmlLabel2, htmlLabel3 };
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    labels[i].Text = Reader[i].ToString();
                    Console.WriteLine(Reader[i].ToString());
                }
            }
            connection.Close();
