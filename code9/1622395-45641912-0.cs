    public void race_combo()
    {
        MySqlConnection con = new MySqlConnection(connection);
        MySqlCommand cmd = new MySqlCommand("SELECT DATE_FORMAT(id_race , "%Y-%m-%d") AS id_race FROM race", con);
        MySqlDataReader msdr;
    
        try
        {
            con.Open();
            msdr = cmd.ExecuteReader();
            while (msdr.Read())
            {
                string team_id = msdr.GetString("id_race");
                MessageBox.Show(team_id);
                comboBox4.Items.Add(team_id);
                comboBox6.Items.Add(team_id);
                comboBox9.Items.Add(team_id);
    
            }
            con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
