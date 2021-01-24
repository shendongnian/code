    // change the mysql command - you are missing the "FROM" clause in your mysql command 
        MySqlCommand command = new MySqlCommand("SELECT * FROM WHERE Username='" + txtboxUsername.Text + "' and Password= '" + txtboxPassword.Text + "'", connection);
                        MySqlDataReader reader;
                        reader = command.ExecuteReader();
                        DataTable ft = new System.Data.DataTable();
                        no.Fill(ft);
                        while (reader.Read())
                        {
                            lblPosition.Text = ft.Rows[1]["Position"].ToString();
                            panelLogin.Hide();
                            panel1.Show();
                        }
