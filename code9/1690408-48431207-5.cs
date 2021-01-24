    string sql = 
        "SELECT a.id as AccountID, a.name, p.id as PictureID, p.width, p.height" + 
        " FROM accounts a" +
        " INNER JOIN pictures p on p.account_id = a.id" +
        " ORDER BY a.name, a.id";
    using (var cn = new MySqlConnection("host=..."))
    using (var cmd = new MySqlCommand(sql, cn))
    {
        cn.Open();
        using (var rdr = cmd.ExecuteReader())
        {
            bool reading = rdr.Read();
            while (reading)
            {
                int CurrentAccount = rdr.GetInt32("AccountId");
                Console.WriteLine("Account {0}:", rdr.GetString("name"));
                while (reading && CurrentAccount == rdr.GetInt32("AccountId"))
                {
                   Console.WriteLine("\tPicture #{0}: {1} x {2}", 
                     rdr.GetInt32("PictureId"), rdr.GetInt32("width"), rdr.GetInt32("height"));
                   reading = rdr.Read();
                }
            }
        }
    }
