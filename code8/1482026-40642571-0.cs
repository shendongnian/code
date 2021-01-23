    while (dr2.Read())
    {
          int col = dr2.GetOrdinal("TABLE_NAME");
          if (!comboBox1.Items.Contains(dr2[col].ToString()))
          {
              comboBox1.Items.Add(dr2[col].ToString());
          }
    }
