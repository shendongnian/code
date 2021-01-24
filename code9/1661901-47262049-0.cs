     string ChaineDeSelction = "SELECT fir_mdnt FROM -- WHERE fir_aktiv = 1 AND EXISTS(select firbpv_fir from --)";
            OdbcConnection MyConnec = new OdbcConnection(MyConnString);
            MyConnec.Open();
            OdbcCommand MyComm = new OdbcCommand(ChaineDeSelction, MyConnec);
            OdbcDataReader reader = MyComm.ExecuteReader();
            while (reader.Read())
            {
                _cb_Societe.Items.Add(reader[0]);
            };
