    using (MySqlDataReader reader2 = cmd2.ExecuteReader()) { 
    
          while (reader2.Read())
          {
             string item = reader2["ID"].ToString();
             lastIndex = int.Parse(item);
             lastIndex++;
             lastID = lastIndex.ToString();
          }
    }
