    using (MySqlConnection connection = new MySqlConnection("host=..."))
    using (MySqlCommand cmdAccounts = MySqlCommand("SELECT id, name FROM accounts" , connection))
    {
        connection.Open();
        using (MySqlConnection connection2 = new MySqlConnection("host=..."))
        using (MySqlCommand cmdPictures = new MySqlCommand("SELECT id, width, height FROM pictures WHERE account_id = @accountId", connection2))
        using (MySqlDataReader accounts = cmdAccounts.ExecuteReader())
        {
            cmdPictures.Parameters.Add("@accountId", MySqlDbType.Int32); 
            connection2.Open()
            while (accounts.Read())
            {    
                Console.WriteLine("Account {0}:", account.getString("name"));
    
                cmdPictures.Parameters["@accountId"].Value = accounts.GetInt32("id");
    
                using (MySqlDataReader pictures = cmdPictures.ExecuteReader())
                {
                    while (pictures.Read())
                    {
                        Console.WriteLine("\tPicture #{0}: {1} x {2}", pictures.GetInt32("id"), picture2.GetInt32("width"), picture2.GetInt32("height"));
                    }
                }
            }
        }
    }
