    try
            {
                int i = 0;
                using (SqlConnection sqlCon = new SqlConnection(Form1.connectionString))
                {
                    string commandString = "SELECT RollNO  FROM Student1";
                    comboBox3.Items.Clear(); //first clear previous items then refill
                    // MessageBox.Show(commandString);
                    SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);
                    sqlCon.Open();
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    while (dr.Read())
                    {
                        i = 1;
                        comboBox3.Items.Add(dr[0]);
                    }
                    dr.Close();
                }
                if (i == 0)
                {
                    MessageBox.Show("Database Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
