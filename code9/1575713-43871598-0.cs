    using (MySqlConnection conn = new MySqlConnection("Server=localhost;Uid=root;Pwd=root;Database=Sql300365_1"))
    {
            conn.Open();
            Int32 numTotali = Int32.Parse(getCount());
            for (int i = numTotali - 1; i >= 0; i--)
            {
                 query = "UPDATE " + table + " SET " + table + ".Priorita  = ?PrioritaSet WHERE Priorita = ?Priorita";
                 cmd = new MySqlCommand(query, conn);
                 cmd.Parameters.Add("?Priorita", MySqlDbType.Int64).Value = i;
                 cmd.Parameters.Add("?PrioritaSet", MySqlDbType.Int64).Value = i + 1;
                 cmd.ExecuteNonQuery();
            }
              
       query = "INSERT INTO " + table + " (Priorita,  Data, Titolo) VALUES (0, ?Data, ?Titolo)";
       cmd = new MySqlCommand(query, conn);
       cmd.Parameters.Add("?Data", MySqlDbType.VarChar, ConstDao.LENGHT_NEWS_DATA).Value = news.Data;
       cmd.Parameters.Add("?Titolo", MySqlDbType.VarChar, ConstDao.LENGHT_NEWS_TITOLO).Value = news.Titolo;
       cmd.ExecuteNonQuery();
       news.IdNumber = cmd.LastInsertedId.ToString();                    
                        
       scope.Complete();
    }
