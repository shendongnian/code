    private void comboSolectwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("SELECT * FROM solectwa WHERE nazwa='"+comboSolectwo.Text+"';", mysqlCon);
                MySqlDataReader mysqlDr = mySqlCmd.ExecuteReader();
                while (mysqlDr.Read())
                {
                    string sID = mysqlDr.GetInt32("idsolectwa").ToString();
                    txtIDSolectwo.Text = sID;
                }
                
            }
            
        }
