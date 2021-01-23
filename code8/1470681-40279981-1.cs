            string str = "Server=.\\SQL2008R2;Database=Practice;User ID=sa;Password=123;Trusted_Connection=True;Connection Timeout=0";
            string query1 = "SELECT * from tblTest Where Cell = " + textBox1.Text;
            using (var conn = new SqlConnection(str))
            using (var cmd = new SqlCommand(query1, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string aa = reader.GetString(0);
                }
                conn.Close();
            }
