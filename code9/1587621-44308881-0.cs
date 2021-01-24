    void fill_List()
    {
        using(OleDbConnection konekcija = new OleDbConnection(......))
        using(OleDbCommand komPrikaz = new OleDbCommand("SELECT * FROM GORIVO ORDER BY GorivoID ASC", konekcija))
        {
              DataTable dt = new DataTable();
              konekcija.Open();
              OleDbDataAdapter adapter = new OleDbDataAdapter(komPrikaz);
              adapter.Fill(dt);
              listBox1.Items.Clear();
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                    string pom;
                    pom = dt.Rows[i][0].ToString() + " " + dt.Rows[i][1].ToString() + " " + dt.Rows[i][2];
                    listBox1.Items.Add(pom);
              }
         }
    }
