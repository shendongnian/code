    using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
    {
        cmd.Parameters.Add(new MySqlParameter("@Group", MySqlDbType.VarChar));
        cmd.Parameters.Add(new MySqlParameter("@Name", MySqlDbType.VarChar));
        for (int i = 0; i < EmpList.Count; i++)
        {
            cmd.Parameters["Group"].Value = group;
            cmd.Parameters["Name"].Value = EmpList[i].Name;
            // rest of code here
           using (MySqlDataReader reader = cmd.ExecuteReader())
           {
               // Process reader operations 
           }
        }
    }
