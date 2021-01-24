    private void Update(int id, string kundenname, string game, string bezahlung, string bezahlt, string erledigt,
            string payPalEmail,
            string accEmail, string accPw)
        {
            //SQL STMT
            /*var sql = "UPDATE kunden SET Kundenname='" + kundenname + "',Game='" + game + "',Bezahlung='" + bezahlung +
                      "',Bezahlt='" + bezahlt + "',Erledigt='" + erledigt + "',PayPalEmail='" + payPalEmail +
                      "',ACCEmail='" + accEmail + "',ACCPW='" + Encrypt(accPw) + "' WHERE ID=" + id + "";*/
            string sql = "UPDATE kunden " +
                         " SET Kundenname=@kundenname, Game=@game, Bezahlung=@bezahlung, Bezahlt=@bezahlt, Erledigt=@erledigt, PayPalEmail=paypalemail, ACCEmail=accenail, ACCPW=accpw WHERE ID="+ id + "";            //_cmd = new MySqlCommand(sql, _con);
            _cmd = new MySqlCommand(sql, _con);
            _cmd.Parameters.Add(new MySqlParameter("@kundenname",kundenname));
            _cmd.Parameters.Add(new MySqlParameter("@game",game));
            _cmd.Parameters.Add(new MySqlParameter("@bezahlung",bezahlung));
            _cmd.Parameters.Add(new MySqlParameter("@bezahlt",bezahlt));
            _cmd.Parameters.Add(new MySqlParameter("@erledigt",erledigt));
            _cmd.Parameters.Add(new MySqlParameter("@paypalemail",payPalEmail));
            _cmd.Parameters.Add(new MySqlParameter("@accemail",accEmail));
            _cmd.Parameters.Add(new MySqlParameter("@accpw",accPw));
            /*
            _cmd.Parameters.Add("@kundenname", MySqlDbType.VarChar).Value = kundenname;
            _cmd.Parameters.Add("@game", MySqlDbType.VarChar).Value = game;
            _cmd.Parameters.Add("@bezahlung", MySqlDbType.VarChar).Value = bezahlung;
            _cmd.Parameters.Add("@bezahlt", MySqlDbType.VarChar).Value = bezahlt;
            _cmd.Parameters.Add("@erledigt", MySqlDbType.VarChar).Value = kundenname;
            _cmd.Parameters.Add("@paypalemail", MySqlDbType.VarChar).Value = game;
            _cmd.Parameters.Add("@accemail", MySqlDbType.VarChar).Value = bezahlung;
            _cmd.Parameters.Add("@accpw", MySqlDbType.VarChar).Value = bezahlt;*/
            //OPEN CON,UPDATE,RETRIEVE DGVIEW
            try
            {
                _con.Open();
                _adapter = new MySqlDataAdapter(_cmd)
                {
                    UpdateCommand = _con.CreateCommand()
                };
                _adapter.UpdateCommand.CommandText = sql;
                if (_adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    ClearTxts();
                    MessageBox.Show(@"Successfully Updated");
                }
                _con.Close();
                Retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _con.Close();
            }
        }
