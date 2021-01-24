    MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT number FROM numbers ORDER BY RAND() LIMIT 2; ";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
    int i=0;
                HtmlLabel[] labels = new HtmlLabel[] { htmlLabel1, htmlLabel2, htmlLabel3 };
            while (Reader.Read())
            {
                //for (int i = 0; i < Reader.FieldCount; i++)
                //{
                    labels[i].Text = Reader[0].ToString();
                    Console.WriteLine(Reader[0].ToString());
                //}
    i +=1;
            }
            connection.Close();
