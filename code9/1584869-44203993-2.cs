     const string connMysql = "DataSource=localhost; Database=ph; Uid=root; Pwd=;";
            myConn = new MySqlConnection(connMysql);
            string cad = "SELECT answers FROM `questions` WHERE (`test_num` = '1')";
            myConn.Close();
            myConn.Open();
            myCommand = new MySqlCommand(cad, myConn);
            myReader = myCommand.ExecuteReader();     
            int i = 0;
            CB1.Items.Clear(); //Clear the Combo box once before adding values
            while(myReader.Read())
            {
                CB1.Items.Add(myReader[i].ToString());
                i++;
            }
