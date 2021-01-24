		void CheckAirCraft()
        {
            string a = comboBox1.Text;
            string ConString = " datasource = localhost; port = 3306; username = root; password = 3306";
            string sql = "SELECT count (*) FROM [initialentry] WHERE aircraft_number = @a";
            using (MySqlConnection cn = new MySqlConnection(ConString))
            {
                cn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@a", a);
                    var result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result > 0)
                    {
                        label1.Text = "Record exists";
                    }
                    else
                    {
                        label1.Text = "Record does not exist";
                    }
                }
            }
            }
