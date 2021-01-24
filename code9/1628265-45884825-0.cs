    private void referenzDropDown(object sender, EventArgs e)
    {
        string myInsertQuery = "SHOW TABLES";
        MySqlCommand myCommand = new MySqlCommand(myInsertQuery, myConnection);
        MySqlDataReader myReader;
        myReader = myCommand.ExecuteReader();
        // the "sender" is the control raising this event
        // parse it to ComboBox
        ComboBox actualSelectedComboBox = (ComboBox)sender;
        actualSelectedComboBox.Items.Clear();
        // ...
