    foreach (DataGridViewRow row in Dataview.Rows)
    {
      if (!row.IsNewRow) {
        string sqlSelectAll = "UPDATE klant SET Klant_ID = '" + row.Cells["Klant_ID"].
        Value + "', Voornaam = '" + row.Cells["Voornaam"].
        Value + "', Achternaam = '" + row.Cells["Achternaam"].
        Value + "', Adres = '" + row.Cells["Adres"].
        Value + "', Woonplaats = '" + row.Cells["Woonplaats"].Value;
        MySqlCommand c = new MySqlCommand(sqlSelectAll, con);
        c.ExecuteNonQuery();
      }
      else {
        // new row skipped
      }
    }
