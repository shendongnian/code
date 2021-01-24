     MySqlConnection connection = new MySqlConnection    ("SERVER=127.0.0.1;DATABASE=xo_game;UID=root;PASSWORD=;");
       try
       {
       connection.Open();
     MySqlCommand cmd = new MySqlCommand("SELECT id, player_one, player_two,   CASE avaible WHEN 1 THEN 'Available' ELSE 'Not available' END as 'avaible' FROM games", connection);
     MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
     DataSet ds = new DataSet();
     adp.Fill(ds, "LoadDataBinding");
     dataGridGames.DataContext = ds;
     }
     catch (MySqlException ex)
     {
     MessageBox.Show(ex.ToString());
     }
     finally
     {
     connection.Close();
     }
