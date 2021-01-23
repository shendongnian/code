    List<string> playerNames; 
    void fill_listbox()
    {
        string constring = "datasource=localhost;port=3306;username=root;password=xdmemes123";
        string Query = "select * from life.players ;";
        MySqlConnection conDataBase = new MySqlConnection(constring);
        MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
        MySqlDataReader myReader;
        try
        {
            conDataBase.Open();
            myReader = cmdDataBase.ExecuteReader();
            while (myReader.Read())
            {
                string sName = myReader.GetString("name");
                playerNames.Add(sName);
            }
            foreach(string name in playerNames)
            {
                namelistbox.Items.Add(name);
            }
            
        }catch (Exception ex)
        {
            MessageBox.Show("Something went wrong. Error copied to clipboard.");
            Clipboard.SetText(ex.Message);
        }
    }
