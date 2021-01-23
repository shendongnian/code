    public void LoadSubjects()
        {
            List<ProjectItem> items = new List<ProjectItem>();
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT ID, Naam FROM projecten";
                    MySqlCommand comm = new MySqlCommand(query, con);
                    MySqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader["ID"];
                        string nm = (string)reader["Naam"];
                        items.Add(new ProjectItem(id, nm));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(items.ToArray<ProjectItem>());  
        }
