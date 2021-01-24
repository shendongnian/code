       private void button4_Click(object sender, EventArgs e)
        {
            string value1 = listBox2.Text;
            string value2 = listBox1.Text;
    
            MySqlDataReader dr = null;
    
            try
            {
                String cs = "Database=something;User=-;Password=-";
                string selectStatement = "UPDATE reservasjon SET Rom_nr='"+value2+"' WHERE Rnr='"value1+"';";
                System.Data.DataTable dt = new System.Data.DataTable();
                MySqlConnection dbconn = new MySqlConnection(cs);
                dbconn.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter();
                sqlDa.SelectCommand = new MySqlCommand(selectStatement, dbconn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(sqlDa);
                sqlDa.Fill(dt);
                dt.Rows[0]["Rnr"] = "";
                sqlDa.UpdateCommand = cb.GetUpdateCommand();
                sqlDa.Update(dt);
            }
    
            catch (Exception s)
            {
                Console.WriteLine(s.Message);
            }
        }
