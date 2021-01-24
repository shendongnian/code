    command.CommandText =
        @"SELECT [vertaling], [woord], [gebruiker]
          FROM [tbWoorden]
          WHERE [woord] = 'ans'";
    using (var reader = command.ExecuteReader())
    {
        int woordIndex = reader.GetOrdinal("woord");
        int vertalingIndex = reader.GetOrdinal("vertaling");
        int gebruikerIndex = reader.GetOrdinal("gebruiker");
        while (reader.Read())
            dataGridView1.Rows.Add(new object[] {
                reader.GetValue(woordIndex),
                reader.GetValue(vertalingIndex),
                reader.GetValue(gebruikerIndex)
            });
    }
