    string type = "Cash";
    string type1 = "Card";
    if (radioButton1.Checked)
    {
      myDB.Open();
      OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM [Transaction]", myDB);
      adapter.Fill(dt);
      OleDbCommand cmd = new OleDbCommand(@"INSERT INTO [Transaction](Type, Amount) Values ('" + type + "', " + label3.Text + ")", myDB);
      cmd.ExecuteNonQuery();
    }
    else if(radioButton2.Checked)
    {
      OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM [Transaction]", myDB);
    adapter.Fill(dt);
      OleDbCommand cmd = new OleDbCommand(@"INSERT INTO [Transaction](Type, Amount) Values ('" + type1 + "', " + label3.Text + ")", myDB);
      cmd.ExecuteNonQuery();
    }
    myDB.Close();
