         using(MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=project;username=root;password=***;"))
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO test_results (test_results) VALUES (@testResults);");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@testResults", correctAnswers);
            connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection = connection;
        }
