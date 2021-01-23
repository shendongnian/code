            MySqlConnection conn = new                                     MySqlConnection("Server=localhost;Database=basket;Uid=root;pwd=;");
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "select * from tblhighscore where id = 0";
            command.Parameters.AddWithValue("@CurrScore", CurrScore);
            MySqlDataReader reader = command.ExecuteReader();
            conn.Close();
        }` 
