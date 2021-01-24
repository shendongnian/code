     List<MySqlReadUpdate> dbData = new List<MySqlReadUpdate>();
     var config = "server=localhost;user id=root;database=restaurants;pooling=false;SslMode=none";
     MySqlConnection con = new MySqlConnection(config);
     MySqlConnection cmdCon = new MySqlConnection(config);
     MySqlDataReader reader = null;
     string query = "SELECT id, notes FROM customers";
     MySqlCommand command = new MySqlCommand(query, con);
     con.Open();
     cmdCon.Open();
     reader = command.ExecuteReader();
     while (reader.Read())
     {
         MySqlReadUpdate newMySqlReadUpdate = new MySqlReadUpdate();
         newMySqlReadUpdate.Id = (int)reader["id"];
         newMySqlReadUpdate.Notes = (string)reader["notes"];
         string note = newMySqlReadUpdate.Notes;
         var notesplit = note.Split(' ', '\n')[1];
         dbData.Add(newMySqlReadUpdate);
         Console.WriteLine(newMySqlReadUpdate.Id);
         Console.WriteLine(newMySqlReadUpdate.Notes);
         Console.WriteLine(note);
         Console.WriteLine(notesplit);
         string query2 = "UPDATE customers SET notes='" + notesplit + "' WHERE id='" + newMySqlReadUpdate.Id + "';";
         MySqlCommand update = new MySqlCommand(query2, cmdCon);
         update.ExecuteNonQuery();
     }
     con.Close();
     cmdCon.Close();
     Console.WriteLine("Finished!");
     Console.Read();
