    //
    comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    //
    string query = "SELECT SomeThing";
    List<string> rw = new List<string>();
    try
    {
        using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Neth1.accdb"))
        {
            con.Open();
            using (OleDbCommand oCmd = new OleDbCommand(query, con))
            {
                using (OleDbDataReader _reader = oCmd.ExecuteReader())
                {
                    if (_reader.HasRows == false) { return; }
                     while (_reader.Read())
                     {
                        rw.Add((string)_reader["IMEI"]);
                     }
                }
            }
        }
    }
    catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
         comboBox1.AutoCompleteCustomSource.Clear();
         comboBox1.AutoCompleteCustomSource.AddRange(rw.ToArray());
         rw = null;
