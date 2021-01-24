     public static void OnInfoMessage(object sender, MySqlInfoMessageEventArgs e)
        {
            foreach (MySqlError err in e.errors)
            {
                Console.WriteLine(err.Code + ":" + err.Message);
            }
    
        }
