    using (MySQLHelper LeftCurrent = new MySQLHelper())
    {
      string mysql = "Select BandColor as LeftSideCurrentBandColor from band WHERE PnBanda LIKE '" + textBoxLeftSideCurrentBandColor.Text + "'";
    
      MySqlCommand LeftCurrentCommand = LeftCurrent.GetCommand(mysql);
      textBoxLeftSideCurrentBandColor.BackColor = System.Drawing.Color.FromName((LeftCurrentCommand.ExecuteOracleScalar() ?? "RED").ToString());
    }
